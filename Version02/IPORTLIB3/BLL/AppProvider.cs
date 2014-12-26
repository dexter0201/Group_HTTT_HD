using IDAL;
using System.Reflection;
using System.IO;
using System;
using By1112292;

namespace BLL
{
    public class AppProvider : BaseProvider
    {
        static UserEnrollProvider _userEnroll = null;
        public static UserEnrollProvider UserEnroll
        {
            get
            {
                if (_userEnroll == null)
                    _userEnroll = new UserEnrollProvider((IUserEnrollRepository)GetType("userEnroll"));
                return _userEnroll;
            }
        }
        static ConfigProvider _config = null;
        public static ConfigProvider Config
        {
            get
            {
                if (_config == null)
                    _config = new ConfigProvider((IConfigRepository)GetType("config"));
                return _config;
            }
        }
        static CountryProvider _country = null;
        public static CountryProvider Country
        {
            get
            {
                if (_country == null)
                    _country = new CountryProvider((ICountryRepository)GetType("country"));
                return _country;
            }
        }
        static PurchaseProvider _purchase = null;
        public static PurchaseProvider Purchase
        {
            get
            {
                if (_purchase == null)
                    _purchase = new PurchaseProvider((IPurchaseRepository)GetType("purchase"));
                return _purchase;
            }
        }
        static ProvinceProvider _province = null;
        public static ProvinceProvider Province
        {
            get
            {
                if (_province == null)
                    _province = new ProvinceProvider((IProvinceRepository)GetType("province"));
                return _province;
            }
        }
        static PurchaseDetailProvider _purchaseDetail = null;
        public static PurchaseDetailProvider PurchaseDetail
        {
            get
            {
                if (_purchaseDetail == null)
                    _purchaseDetail = new PurchaseDetailProvider((IPurchaseDetailRepository)GetType("purchaseDetail"));
                return _purchaseDetail;
            }
        }
        static SupplierProvider _supplier = null;
        public static SupplierProvider Supplier
        {
            get
            {
                if (_supplier == null)
                    _supplier = new SupplierProvider((ISupplierRepository)GetType("supplier"));
                return _supplier;
            }
        }
        static PublisherProvider _publisher = null;
        public static PublisherProvider Publisher
        {
            get
            {
                if (_publisher == null)
                    _publisher = new PublisherProvider((IPublisherRepository)GetType("publisher"));
                return _publisher;
            }
        }
        static OrderProvider _order = null;
        public static OrderProvider Order
        {
            get
            {
                if (_order == null)
                    _order = new OrderProvider((IOrderRepository)GetType("order"));
                return _order;
            }
        }
        static AuthorProvider _author = null;
        public static AuthorProvider Author
        {
            get
            {
                if (_author == null)
                    _author = new AuthorProvider((IAuthorRepository)GetType("author"));
                return _author;
            }
        }
        static OrderDetailProvider _orderDetail = null;
        public static OrderDetailProvider OrderDetail
        {
            get
            {
                if (_orderDetail == null)
                    _orderDetail = new OrderDetailProvider((IOrderDetailRepository)GetType("orderDetail"));
                return _orderDetail;
            }
        }
        static TopicProvider _topic = null;
        public static TopicProvider Topic
        {
            get
            {
                if (_topic == null)
                    _topic = new TopicProvider((ITopicRepository)GetType("topic"));
                return _topic;
            }
        }
        static PublicationTypeProvider _publicationType = null;
        public static PublicationTypeProvider PublicationType
        {
            get
            {
                if (_publicationType == null)
                    _publicationType = new PublicationTypeProvider((IPublicationTypeRepository)GetType("publicationType"));
                return _publicationType;
            }
        }
        static UnitProvider _unit = null;
        public static UnitProvider Unit
        {
            get
            {
                if (_unit == null)
                    _unit = new UnitProvider((IUnitRepository)GetType("unit"));
                return _unit;
            }
        }
        static CurrencyProvider _currency = null;
        public static CurrencyProvider Currency
        {
            get
            {
                if (_currency == null)
                    _currency = new CurrencyProvider((ICurrencyRepository)GetType("currency"));
                return _currency;
            }
        }
        static MajorProvider _major = null;
        public static MajorProvider Major
        {
            get
            {
                if (_major == null)
                    _major = new MajorProvider((IMajorRepository)GetType("major"));
                return _major;
            }
        }
        static LanguageProvider _language = null;
        public static LanguageProvider Language
        {
            get
            {
                if (_language == null)
                    _language = new LanguageProvider((ILanguageRepository)GetType("language"));
                return _language;
            }
        }
        static PublicationProvider _publication = null;
        public static PublicationProvider Publication
        {
            get
            {
                if (_publication == null)
                    _publication = new PublicationProvider((IPublicationRepository)GetType("publication"));
                return _publication;
            }
        }
        static PeriodProvider _period = null;
        public static PeriodProvider Period
        {
            get
            {
                if (_period == null)
                    _period = new PeriodProvider((IPeriodRepository)GetType("period"));
                return _period;
            }
        }
        static StoreProvider _store = null;
        public static StoreProvider Store
        {
            get
            {
                if (_store == null)
                    _store = new StoreProvider((IStoreRepository)GetType("store"));
                return _store;
            }
        }
        static BookProvider _book = null;
        public static BookProvider Book
        {
            get
            {
                if (_book == null)
                    _book = new BookProvider((IBookRepository)GetType("book"));
                return _book;
            }
        }
        static DepartmentProvider _department = null;
        public static DepartmentProvider Department
        {
            get
            {
                if (_department == null)
                    _department = new DepartmentProvider((IDepartmentRepository)GetType("department"));
                return _department;
            }
        }
        static GroupProvider _group = null;
        public static GroupProvider Group
        {
            get
            {
                if (_group == null)
                    _group = new GroupProvider((IGroupRepository)GetType("group"));
                return _group;
            }
        }
        static AttachmentTypeProvider _attachmentType = null;
        public static AttachmentTypeProvider AttachmentType
        {
            get
            {
                if (_attachmentType == null)
                    _attachmentType = new AttachmentTypeProvider((IAttachmentTypeRepository)GetType("attachmentType"));
                return _attachmentType;
            }
        }
        static AttachmentProvider _attachment = null;
        public static AttachmentProvider Attachment
        {
            get
            {
                if (_attachment == null)
					_attachment = new AttachmentProvider((IAttachmentRepository)GetType("attachment"));
                return _attachment;
            }
        }
        static UserProvider _user = null;
        public static UserProvider User
        {
            get
            {
                if (_user == null)
                    _user = new UserProvider((IUserRepository)GetType("user"));
                return _user;
            }
        }
        static CardUserProvider _cardUser = null;
        public static CardUserProvider CardUser
        {
            get
            {
                if (_cardUser == null)
                    _cardUser = new CardUserProvider((ICardUserRepository)GetType("cardUser"));
                return _cardUser;
            }
        }
        static LoanProvider _loan = null;
        public static LoanProvider Loan
        {
            get
            {
                if (_loan == null)
                    _loan = new LoanProvider((ILoanRepository)GetType("loan"));
                return _loan;
            }
        }
        static LoanDetailProvider _loanDetail = null;
        public static LoanDetailProvider LoanDetail
        {
            get
            {
                if (_loanDetail == null)
                    _loanDetail = new LoanDetailProvider((ILoanDetailRepository)GetType("loanDetail"));
                return _loanDetail;
            }
        }
        static CourseProvider _course = null;
        public static CourseProvider Course
        {
            get
            {
                if (_course == null)
                    _course = new CourseProvider((ICourseRepository)GetType("course"));
                return _course;
            }
        }
        static StatusProvider _status = null;
        public static StatusProvider Status
        {
            get
            {
                if (_status == null)
                    _status = new StatusProvider((IStatusRepository)GetType("status"));
                return _status;
            }
        }
    }
}
