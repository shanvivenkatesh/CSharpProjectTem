using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.Framework.PageObjectsFactory
{
    public interface IElementLocator
    {
        ISearchContext SearchContext { get; }



        /// <summary>
        /// Locates an element using the given list of <see cref="By"/> criteria.
        /// </summary>
        /// <param name="bys">The list of methods by which to search for the element.</param>
        /// <returns>An <see cref="IWebElement"/> which is the first match under the desired criteria.</returns>
        IWebElement LocateElement(IEnumerable<By> bys);



        /// <summary>
        /// Locates a list of elements using the given list of <see cref="By"/> criteria.
        /// </summary>
        /// <param name="bys">The list of methods by which to search for the elements.</param>
        /// <returns>A list of all elements which match the desired criteria.</returns>
        IList<IWebElement> LocateElements(IEnumerable<By> bys);
    }
}
