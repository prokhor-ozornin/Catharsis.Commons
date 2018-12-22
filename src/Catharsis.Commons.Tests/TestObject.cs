﻿using System;
using System.ComponentModel;

namespace Catharsis.Commons
{
  [Serializable]
  public class TestObject : IDisposable, IEquatable<TestObject>
  {
    [Description]
    [DisplayName]
    private object ReadOnlyProperty
    {
      get { return null; }
    }

    [Description("PublicStaticProperty Description")]
    [DisplayName("PublicStaticProperty")]
    public static object PublicStaticProperty { get; set; }
    
    protected static object ProtectedStaticProperty { get; set; }
    
    private static object PrivateStaticProperty { get; set; }
    
    [Description("PublicProperty")]
    public object PublicProperty { get; set; }
    
    [DisplayName("ProtectedProperty")]
    protected object ProtectedProperty { get; set; }
    
    private object PrivateProperty { get; set; }

    [Description]
    public static object PublicStaticField;
    
    protected static object ProtectedStaticField;
    
    private static object PrivateStaticField;
    
    [Description]
    public object PublicField;
    
    protected object ProtectedField;
    
    private object PrivateField;

    public delegate void PublicDelegate();
    
    protected delegate void ProtectedDelegate();
    
    private delegate void PrivateDelegate();
    
    public event PublicDelegate PublicEvent;
    
    protected event ProtectedDelegate ProtectedEvent;
    
    private event PrivateDelegate PrivateEvent;

    public TestObject()
    {
    }
    
    public TestObject(object publicProperty)
    {
      this.PublicProperty = publicProperty;
    }

    public static void PublicStaticMethod()
    {
    }

    protected static void ProtectedStaticMethod()
    {
    }

    private static void PrivateStaticMethod()
    {
    }

    [Description]
    public void PublicMethod()
    {
    }

    protected void ProtectedMethod()
    {
    }

    private void PrivateMethod()
    {
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public virtual bool Equals(TestObject other)
    {
      return this.Equality(other, it => it.PublicProperty, it => it.PublicProperty);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as TestObject);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.PublicProperty, it => it.PublicProperty);
    }
  }
}