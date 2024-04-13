using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peliculas.Models.Shared
{
    public partial class Pager
    {
        public int CurrentPage { get; set; } = 1;
        public int ItemsPerPage { get; set; } = Config.Config.Pager.DefaultPageSize;
        public string Action { get; set; }
        public string Controller { get; set; }
        public string UpdateTargetId { get; set; }
        public int TotalItems { get; set; }
        public int TotalPageCount { get; set; }
        public string PagerHtmlId { get; set; }

        private static List<int> _ItemsPerPageOptionList { get; set; }
        public List<int> ItemsPerPageOptionList
        {
            get
            {
                if (_ItemsPerPageOptionList == null)
                {
                    _ItemsPerPageOptionList = Config.Config.Pager.ItemsPerPageOptions;
                }
                return _ItemsPerPageOptionList;
            }
        }

        public Pager()
        {

        }

        public Pager(int _totalItems, int _totalPageCount, string _action, string _controller, string _updateTargetId, int _currentPage = 1,
            int _itemsPerPage = Config.Config.Pager.DefaultPageSize, string _pagerHtmlId = "pager")
        {
            TotalItems = _totalItems;
            TotalPageCount = _totalPageCount;

            Action = _action;
            Controller = _controller;
            UpdateTargetId = _updateTargetId;

            if (_currentPage < 1)
            {
                CurrentPage = 1;
            }
            else if (_currentPage > TotalPageCount && TotalPageCount > 0)
            {
                CurrentPage = TotalPageCount;
            }
            else
            {
                CurrentPage = _currentPage;
            }
            ItemsPerPage = _itemsPerPage;
            PagerHtmlId = _pagerHtmlId;
        }
    }
}