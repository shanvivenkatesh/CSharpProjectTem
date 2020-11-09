using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpTemplate.Framework.PageObjectsFactory
{
    public class DefaultElementLocator : IElementLocator
    {
        private ISearchContext searchContext;



        public DefaultElementLocator(ISearchContext searchContext)
        {
            this.searchContext = searchContext;
        }



        /// <summary>
        /// Gets the <see cref="ISearchContext"/> to be used in locating elements.
        /// </summary>
        public ISearchContext SearchContext
        {
            get { return this.searchContext; }
        }



        /// <summary>
        /// Locates an element using the given list of <see cref="By"/> criteria.
        /// </summary>
        /// <param name="bys">The list of methods by which to search for the element.</param>
        /// <returns>An <see cref="IWebElement"/> which is the first match under the desired criteria.</returns>
        public IWebElement LocateElement(IEnumerable<By> bys)
        {
            if (bys == null)
            {
                throw new ArgumentNullException("bys", "List of criteria may not be null");
            }



            string errorString = null;
            foreach (var by in bys)
            {
                try
                {
                    return this.searchContext.FindElement(by);
                }
                catch (NoSuchElementException)
                {
                    errorString = (errorString == null ? "Could not find element by: " : errorString + ", or: ") + by;
                }
            }



            throw new NoSuchElementException(errorString);
        }



        /// <summary>
        /// Locates a list of elements using the given list of <see cref="By"/> criteria.
        /// </summary>
        /// <param name="bys">The list of methods by which to search for the elements.</param>
        /// <returns>A list of all elements which match the desired criteria.</returns>
        public IList<IWebElement> LocateElements(IEnumerable<By> bys)
        {
            if (bys == null)
            {
                throw new ArgumentNullException("bys", "List of criteria may not be null");
            }



            List<IWebElement> collection = new List<IWebElement>();
            foreach (var by in bys)
            {
                IList<IWebElement> list = this.searchContext.FindElements(by);
                collection.AddRange(list);
            }



            return collection.AsReadOnly();
        }
    }
}
