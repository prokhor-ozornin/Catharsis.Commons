﻿using System;
using System.Xml.Linq;
using Xunit;

namespace Catharsis.Commons.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DownloadsCategory"/>.</para>
  /// </summary>
  public sealed class DownloadsCategoryTests : CategoryUnitTests<DownloadsCategory>
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="DownloadsCategory.Xml(XElement)"/> method.</para>
    /// </summary>
    [Fact]
    public void Xml_Method()
    {
      Assert.Throws<ArgumentNullException>(() => DownloadsCategory.Xml(null));

      var xml = new XElement("DownloadsCategory",
        new XElement("Id", "id"),
        new XElement("Language", "language"),
        new XElement("Name", "name"));
      var category = DownloadsCategory.Xml(xml);
      Assert.True(category.Id == "id");
      Assert.True(category.Description == null);
      Assert.True(category.Language == "language");
      Assert.True(category.Name == "name");
      Assert.True(category.Parent == null);
      Assert.True(new DownloadsCategory("id", "language", "name").Xml().ToString() == xml.ToString());
      Assert.True(DownloadsCategory.Xml(category.Xml()).Equals(category));

      xml = new XElement("DownloadsCategory",
        new XElement("Id", "id"),
        new XElement("Description", "description"),
        new XElement("Language", "language"),
        new XElement("Name", "name"),
        new XElement("Parent",
          new XElement("Id", "parent.id"),
          new XElement("Language", "parent.language"),
          new XElement("Name", "parent.name")));
      category = DownloadsCategory.Xml(xml);
      Assert.True(category.Id == "id");
      Assert.True(category.Description == "description");
      Assert.True(category.Language == "language");
      Assert.True(category.Name == "name");
      Assert.True(category.Parent.Id == "parent.id");
      Assert.True(category.Parent.Language == "parent.language");
      Assert.True(category.Parent.Name == "parent.name");
      Assert.True(new DownloadsCategory("id", "language", "name", new DownloadsCategory("parent.id", "parent.language", "parent.name"), "description").Xml().ToString() == xml.ToString());
      Assert.True(DownloadsCategory.Xml(category.Xml()).Equals(category));
    }
  }
}