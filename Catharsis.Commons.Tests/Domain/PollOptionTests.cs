﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Catharsis.Commons.Extensions;
using Xunit;

namespace Catharsis.Commons.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="PollOption"/>.</para>
  /// </summary>
  public sealed class PollOptionTests : EntityUnitTests<PollOption>
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="PollOption.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new PollOption { Text = null });
      Assert.Throws<ArgumentException>(() => new PollOption { Text = string.Empty });
      Assert.True(new PollOption { Text = "text" }.Text == "text");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="PollOption()"/>
    ///   <seealso cref="PollOption(IDictionary{string, object})"/>
    ///   <seealso cref="PollOption(string, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var option = new PollOption();
      Assert.True(option.Id == null);
      Assert.True(option.Text == null);

      Assert.Throws<ArgumentNullException>(() => new PollOption(null));
      option = new PollOption(new Dictionary<string, object>()
        .AddNext("Id", "id")
        .AddNext("Text", "text"));
      Assert.True(option.Id == "id");
      Assert.True(option.Text == "text");

      Assert.Throws<ArgumentNullException>(() => new PollOption(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new PollOption("id", null));
      Assert.Throws<ArgumentException>(() => new PollOption(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new PollOption("id", string.Empty));
      option = new PollOption("id", "text");
      Assert.True(option.Id == "id");
      Assert.True(option.Text == "text");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="PollOption.Xml(XElement)"/></description></item>
    ///     <item><description><see cref="PollOption.Xml()"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Xml_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => PollOption.Xml(null));

      var xml = new XElement("PollOption",
        new XElement("Id", "id"),
        new XElement("Text", "text"));
      var option = PollOption.Xml(xml);
      Assert.True(option.Id == "id");
      Assert.True(option.Text == "text");
      Assert.True(new PollOption("id", "text").Xml().ToString() == xml.ToString());
      Assert.True(PollOption.Xml(option.Xml()).Equals(option));
    }
  }
}