using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DevExpress.XtraNavBar;

namespace ReportManager
{
    public class EventCollection
    {
        public static void Add(string name, NavBarLinkEventHandler e)
        {
            eventList[name] = e;
        }

        public static NavBarLinkEventHandler Get(string name)
        {
            if (eventList.Contains(name))
            {
                return (NavBarLinkEventHandler)eventList[name];
            }
            else
            {
                return null;
            }
        }

        public static IAsyncResult Invoke(object obj, string eventName, NavBarItem baritem, NavBarItemLink link)
        {
            if (eventName != "")
            {
                if (eventName[0] == '*')
                {
                    // asynchronous
                    eventName = eventName.Remove(0, 1);
                    NavBarLinkEventHandler eh = (NavBarLinkEventHandler)Get(eventName);
                    if (eh != null)
                    {
                        NavBarLinkEventArgs args = new NavBarLinkEventArgs(link);
                        IAsyncResult result = eh.BeginInvoke(obj, args, null, null);
                        return result;
                    }

                    return null;
                    // result.AsyncWaitHandle.WaitOne();
                }
                else
                {
                    // synchronous
                    NavBarLinkEventHandler eh = (NavBarLinkEventHandler)Get(eventName);
                    if (eh != null)
                    {
                        NavBarLinkEventArgs args = new NavBarLinkEventArgs(link);
                        eh(obj, args);
                        return null;
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        protected static SortedList eventList = new SortedList();
    }

}
