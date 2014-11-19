namespace DAL
{
    public static class AppProvider
    {
        private static UserProvider _userProvider;
        public static UserProvider UserProvider
        {
            get {
                if (_userProvider == null)
                    _userProvider = new UserProvider();
                return _userProvider; 
            }
        }
        private static DepartmentProvider _deparmentProvider;

        public static DepartmentProvider DeparmentProvider
        {
            get
            {
                if (_deparmentProvider == null)
                    _deparmentProvider = new DepartmentProvider();
                return _deparmentProvider;
            }
        }
        private static ProvinceProvider _provinceProvider;

        public static ProvinceProvider ProvinceProvider
        {
            get {
                if (_provinceProvider == null)
                    _provinceProvider = new ProvinceProvider();
                    return _provinceProvider; 
            }
            
        }
        private static GroupProvider _groupProvider;

        public static GroupProvider GroupProvider
        {
            get
            {
                if (_groupProvider == null)
                    _groupProvider = new GroupProvider();
                return _groupProvider;
            }
        }
        private static AttachmentProvider _attachmentProvider;

        public static AttachmentProvider AttachmentProvider
        {
            get {
                if (_attachmentProvider == null)
                    _attachmentProvider = new AttachmentProvider();
                return _attachmentProvider; 
            }
        }
    }
}
