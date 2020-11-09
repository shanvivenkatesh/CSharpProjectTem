﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace CsharpTemplate.Framework.PageObjectsFactory
{
    public class ByChained : By
    {
        private readonly By[] bys;



        /// <summary>
        /// Initializes a new instance of the <see cref="ByChained"/> class with one or more <see cref="By"/> objects.
        /// </summary>
        /// <param name="bys">One or more <see cref="By"/> references</param>
        public ByChained(params By[] bys)
        {
            this.bys = bys;
        }



        /// <summary>
        /// Find a single element.
        /// </summary>
        /// <param name="context">Context used to find the element.</param>
        /// <returns>The element that matches</returns>
        public override IWebElement FindElement(ISearchContext context)
        {
            IList<IWebElement> elements = this.FindElements(context);
            if (elements.Count == 0)
            {
                throw new NoSuchElementException("Cannot locate an element using " + this.ToString());
            }



            return elements[0];
        }



        /// <summary>
        /// Finds many elements
        /// </summary>
        /// <param name="context">Context used to find the element.</param>
        /// <returns>A readonly collection of elements that match.</returns>
        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            if (this.bys.Length == 0)
            {
                return new List<IWebElement>().AsReadOnly();
            }



            List<IWebElement> elems = null;
            foreach (By by in this.bys)
            {
                List<IWebElement> newElems = new List<IWebElement>();



                if (elems == null)
                {
                    newElems.AddRange(by.FindElements(context));
                }
                else
                {
                    foreach (IWebElement elem in elems)
                    {
                        newElems.AddRange(elem.FindElements(by));
                    }
                }



                elems = newElems;
            }



            return elems.AsReadOnly();
        }



        /// <summary>
        /// Writes out a comma separated list of the <see cref="By"/> objects used in the chain.
        /// </summary>
        /// <returns>Converts the value of this instance to a <see cref="string"/></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (By by in this.bys)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(",");
                }



                stringBuilder.Append(by);
            }



            return string.Format(CultureInfo.InvariantCulture, "By.Chained([{0}])", stringBuilder.ToString());
        }
    }
}
