using System;
using System.Collections.Generic;
using System.Text;

namespace Sdl.Base.Orm
{
    public class SearchBase
    {
        public IPredicate predicate { get; set; }
        public IList<ISort> sort { get; set; }


        private int _totalCount;

        public int totalCount
        {
            get { return _totalCount; }
            set { _totalCount = 0; }
        }
        private int _pageSize;
        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = 0; }
        }
        private int _currentPage;
        public int currentPage
        {
            get { return _currentPage; }
            set { _currentPage = 0; }
        }
    }
}
