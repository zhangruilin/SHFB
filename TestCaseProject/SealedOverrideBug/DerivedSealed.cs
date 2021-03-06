using System;
using System.Runtime.CompilerServices;

namespace TestDoc.SealedOverrideBug
{
    /// <summary>
    /// Fixed by the June 2010 release.
    ///
    /// <p/>This demonstrates a bug in the May 2008 release related protected
    /// members not appearing in the TOC.
    /// </summary>
    [CompilerGenerated]
    class NamespaceDoc
    {
    }

    /* For testing CHM localization
    /// <summary>
    /// A class with localized method names
    /// </summary>
    public class МойКласс
    {
        /// <summary>
        /// A method with a localized name
        /// </summary>
        public void МойМетод()
        {
            // ....
        }
    }*/

    /// <summary>
    /// A base class
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// A protected method. Test UTF-8: propriété attachée
        /// <para>
        /// Another UTF-8 Test:
        /// Implementa el comportamiento de los grupos de trabajo, los cuáles,
        /// en este sistema pueden ser tres
        /// </para>
        /// <para>
        /// And more:
        /// Příliš žluťoučký kůň uháněl s úplavicí
        /// </para>
        /// </summary>
        /// <example>
        /// <code>
        /// // Test UTF-8 chars in code sample: aaaÖÖbbb
        /// </code>
        /// </example>
        protected virtual void SomeMethod()
        {
            Console.WriteLine("Base: Testing!");
        }
    }

    /// <summary>
    /// A sealed derived class
    /// </summary>
    [Obsolete("Obsolete class")]
    public sealed class SealedTest : BaseTest
    {
        /// <summary>
        /// A public constructor
        /// </summary>
        public SealedTest()
        {
        }

        /// <summary>
        /// An override in the sealed class.<br/><br/>Test <b>break</b><br/>Another break.
        /// </summary>
        /// <inheritdoc />
        protected override void SomeMethod()
        {
        }

        /// <summary>
        /// A test
        /// </summary>
        public void CallMethod()
        {
            this.SomeMethod();
        }
    }

    /// <summary>
    /// Another sealed derived class in which SomeMethod() is missing in the TOC
    /// </summary>
    public sealed class FailingClass : BaseTest
    {
        int x;

        /// <summary>
        /// A public constructor
        /// </summary>
        public FailingClass()
        {
            x = 0;
        }

        /// <summary>
        /// An override for the virtual method.  This doesn't show up in
        /// the class documentation for a public build.  reflection.org
        /// contains a reference to the base class method and not this one.
        /// If you use /internal+ or remove the "sealed" keyword, then it
        /// does show up correctly.
        /// </summary>
        protected override void SomeMethod()
        {
            Console.WriteLine("Derived: Testing {0}!", x++);
            base.SomeMethod();
        }

        /// <summary>
        /// A test
        /// </summary>
        public void CallMethod()
        {
            this.SomeMethod();
        }
    }
}
