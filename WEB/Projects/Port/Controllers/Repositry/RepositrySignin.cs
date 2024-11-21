//using Microsoft.EntityFrameworkCore; 
//using Port.Models;

//namespace Port.Controllers.Repository
//{
//    public class RepositrySignin 
//    {
//        private readonly ApplicationDbContext _context;

//        public RepositrySignin(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public void Add(Signin signin)
//        {
//            _context.Signins.Add(signin);
//        }

//        public void Delete(int id)
//        {
//            var signin = GetById(id); 
//            if (signin != null)
//            {
//                _context.Signins.Remove(signin);
//            }
//        }

//        public void Update(Signin signin)
//        {
//            _context.Signins.Update(signin);
//        }

//        public List<Signin> GetAll()
//        {
//            return _context.Signins.ToList();
//        }

//        public Signin GetById(int id)
//        {
//            return _context.Signins.FirstOrDefault(s => s.Id == id);
//        }
//        public void Save()
//        {
//            _context.SaveChanges();
//        }
//    }
//}