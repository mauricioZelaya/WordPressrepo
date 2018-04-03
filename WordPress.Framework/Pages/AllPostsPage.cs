using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPress.Framework.Browser;
using WordPress.Framework.Controls;
using WordPress.Framework.Engine;
using WordPress.Framework.Factories;

namespace WordPress.Framework.Pages
{
    public class AllPostsPage
    {        
        public AllPostsPage GoTo()
        {
            //var element = BrowserManager.Instance.Driver.MouseHover(By.Id("menu-posts"));
            //element.FindElement(By.LinkText("Add New")).Click();

            ControlFactory.GetControl<ContainerElement>(Locator.Id, "menu-posts", "Left Menu")
                .MouseHover()
                .FindElementFromHere(By.LinkText("All Posts"))
                .Click();

            return this;
        }
        
        public AllPostsPage SearchPost(string title)
        {
            ControlFactory.GetControl<TextFieldElement>(Locator.Id, 
                "post-search-input", "Search Post Input").SetValue(title);

            ControlFactory.GetControl<ButtonElement>(Locator.Id,
                "search-submit", "Search Posts").Click();

            return this;
        }

        public void DoesPostExistWithTitle(string title)
        {
            //NOTE:
            //TABLE => XPATH => Advanced XPATH

            var row = 
            ControlFactory.GetControl<TableElement>(Locator.Id,
                "the-list", "Table All Posts")
                .GetRow(title);

            if (row != null && row.Text.Contains(title))
            {
                //LOG
                //
            }
            else
            {
                //LOG
                throw new Exception("Title: " + title + "was not found in All Posts table");
            }

        }
    }
}
