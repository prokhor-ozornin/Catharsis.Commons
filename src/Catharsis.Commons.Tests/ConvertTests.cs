﻿using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Xunit;

namespace Catharsis.Commons
{
  public sealed class ConvertTest
  {
    [Fact]
    public void to()
    {
      Assert.NotNull(Convert.To);
      Assert.True(ReferenceEquals(Convert.To, Convert.To));
    }

    [Fact]
    public void to_boolean()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Boolean(null, new object()));

      Assert.False(Convert.To.Boolean(null));
      Assert.False(Convert.To.Boolean(false));
      Assert.True(Convert.To.Boolean(true));
      Assert.False(Convert.To.Boolean(byte.MinValue));
      Assert.True(Convert.To.Boolean(byte.MaxValue));
      Assert.False(Convert.To.Boolean(char.MinValue));
      Assert.True(Convert.To.Boolean(char.MaxValue));
      Assert.False(Convert.To.Boolean(decimal.MinValue));
      Assert.True(Convert.To.Boolean(decimal.MaxValue));
      Assert.False(Convert.To.Boolean(double.MinValue));
      Assert.True(Convert.To.Boolean(double.MaxValue));
      Assert.False(Convert.To.Boolean(short.MinValue));
      Assert.True(Convert.To.Boolean(short.MaxValue));
      Assert.False(Convert.To.Boolean(int.MinValue));
      Assert.True(Convert.To.Boolean(int.MaxValue));
      Assert.False(Convert.To.Boolean(long.MinValue));
      Assert.True(Convert.To.Boolean(long.MaxValue));
      Assert.False(Convert.To.Boolean(sbyte.MinValue));
      Assert.True(Convert.To.Boolean(sbyte.MaxValue));
      Assert.False(Convert.To.Boolean(Single.MinValue));
      Assert.True(Convert.To.Boolean(Single.MaxValue));
      Assert.False(Convert.To.Boolean(ushort.MinValue));
      Assert.True(Convert.To.Boolean(ushort.MaxValue));
      Assert.False(Convert.To.Boolean(uint.MinValue));
      Assert.True(Convert.To.Boolean(uint.MaxValue));
      Assert.False(Convert.To.Boolean(ulong.MinValue));
      Assert.True(Convert.To.Boolean(ulong.MaxValue));
      Assert.False(Convert.To.Boolean(string.Empty));
      Assert.True(Convert.To.Boolean("string"));
      Assert.False(Convert.To.Boolean(new object[] { }));
      Assert.True(Convert.To.Boolean(new[] { new object() }));
      Assert.True(Convert.To.Boolean(new FileInfo(Assembly.GetExecutingAssembly().Location)));
      Assert.False(Convert.To.Boolean(Stream.Null));
      Assert.False(Convert.To.Boolean(Match.Empty));
      Assert.True(Convert.To.Boolean(Regex.Match("string", ".")));
      Assert.True(Convert.To.Boolean(new object()));
    }

    [Fact]
    public void to_byte()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Byte(null, new object()));

      Assert.Null(Convert.To.Byte(null));
      Assert.Equal(byte.MinValue, Convert.To.Byte(byte.MinValue));
      Assert.Equal(byte.MinValue, Convert.To.Byte(byte.MinValue.ToString(CultureInfo.InvariantCulture)));
      Assert.Null(Convert.To.Byte(new object()));
    }

    [Fact]
    public void to_date_time()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.DateTime(null, new object()));

      Assert.Null(Convert.To.DateTime(null));
      Assert.Equal(DateTime.MinValue, Convert.To.DateTime(DateTime.MinValue));
      Assert.Equal(DateTime.MinValue, Convert.To.DateTime(DateTime.MinValue.ToString(CultureInfo.InvariantCulture)));
      Assert.Null(Convert.To.DateTime(new object()));
    }

    [Fact]
    public void to_decimal()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Decimal(null, new object()));

      Assert.Null(Convert.To.Decimal(null));
      Assert.Equal(decimal.MinValue, Convert.To.Decimal(decimal.MinValue));
      Assert.Equal(decimal.MinValue, Convert.To.Decimal(decimal.MinValue.ToString(CultureInfo.InvariantCulture)));
      Assert.Null(Convert.To.Decimal(new object()));
    }

    [Fact]
    public void to_double()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Double(null, new object()));

      Assert.Null(Convert.To.Double(null));
      Assert.Equal(double.MinValue, Convert.To.Double(double.MinValue));
      Assert.Equal(double.Epsilon, Convert.To.Double(double.Epsilon.ToString()));
      Assert.Null(Convert.To.Double(new object()));
    }

    [Fact]
    public void to_guid()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Guid(null, new object()));

      Assert.Null(Convert.To.Guid(null));
      Assert.Equal(Guid.Empty, Convert.To.Guid(Guid.Empty));
      Assert.Equal(Guid.Empty, Convert.To.Guid(Guid.Empty.ToString()));
      Assert.Null(Convert.To.Guid(new object()));
    }

    [Fact]
    public void to_int16()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Int16(null, new object()));

      Assert.Null(Convert.To.Int16(null));
      Assert.Equal(short.MinValue, Convert.To.Int16(short.MinValue));
      Assert.Equal(short.MinValue, Convert.To.Int16(short.MinValue.ToString(CultureInfo.InvariantCulture)));
      Assert.Null(Convert.To.Int16(new object()));
    }

    [Fact]
    public void to_int32()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Int32(null, new object()));

      Assert.Null(Convert.To.Int32(null));
      Assert.Equal(int.MinValue, Convert.To.Int32(int.MinValue));
      Assert.Equal(int.MinValue, Convert.To.Int32(int.MinValue.ToString(CultureInfo.InvariantCulture)));
      Assert.Null(Convert.To.Int32(new object()));
    }

    [Fact]
    public void to_int64()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Int64(null, new object()));

      Assert.Null(Convert.To.Int64(null));
      Assert.Equal(long.MinValue, Convert.To.Int64(long.MinValue));
      Assert.Equal(long.MinValue, Convert.To.Int64(long.MinValue.ToString(CultureInfo.InvariantCulture)));
      Assert.Null(Convert.To.Int64(new object()));
    }

    [Fact]
    public void to_regex()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Regex(null, new object()));

      Assert.Null(Convert.To.Regex(null));
      var regex = new Regex(".");
      Assert.True(ReferenceEquals(Convert.To.Regex(regex), regex));
      Assert.Equal(new Regex(".").ToString(), Convert.To.Regex(".").ToString());
      Assert.Equal(new Regex(Guid.Empty.ToString()).ToString(), Convert.To.Regex(Guid.Empty).ToString());
    }

    [Fact]
    public void to_single()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Single(null, new object()));

      Assert.Null(Convert.To.Single(null));
      Assert.Equal(Single.MinValue, Convert.To.Single(Single.MinValue));
      Assert.Equal(Single.Epsilon, Convert.To.Single(Single.Epsilon.ToString()));
      Assert.Null(Convert.To.Single(new object()));
    }

    [Fact]
    public void to_string()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.String(null, new object()));

      Assert.Null(Convert.To.String(null));

      const string value = "value";
      Assert.True(ReferenceEquals(Convert.To.String(value), value));
      Assert.Equal(Guid.Empty.ToString(), Convert.To.String(Guid.Empty));
    }

    [Fact]
    public void to_uri()
    {
      Assert.Throws<ArgumentNullException>(() => ConvertExtensions.Uri(null, new object()));

      Assert.Null(Convert.To.Uri(null));
      var uri = new Uri("http://url.com");
      Assert.True(ReferenceEquals(Convert.To.Uri(uri), uri));
      Assert.Equal(uri, Convert.To.Uri("http://url.com"));
    }
  }
}