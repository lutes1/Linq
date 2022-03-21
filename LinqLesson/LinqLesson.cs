namespace LinqLesson
{
    public static class LinqLesson
    {
        public static void Main(string[] args)
        {
            Aggregation();
        }

        private static void PrintCollection<T>(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }

        public static void Filtering()
        {
            // Where (deffered execution)
            var emplyedStudents = _students.Where(student => student.HasAPartTimeJob);

            // Skip
            var allButFirstThree = _students.Skip(3);

            // SkipWhile
            var result = _students.SkipWhile(student => student.Year == 2);
            PrintCollection(result);

            // Take

            // TakeWhile

            // Chunk
            var chunkedResult = _students.Chunk(3);

            // OfType
            var homeStudents = _students.OfType<HomeStudent>();
        }

        public static void Ordering()
        {
            // OrderBy, ThenBy
            var ordered = _students.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ThenBy(x => x.Year).ToList();

            // OrderByDescending, ThenByDescending

            // Reverse
        }

        public static void Quantifiers()
        {
            // Any
            _students.Any(x => x.Year == 4);

            // All
            _students.All(x => x.Year == 4);

            // Contains
            var s1 = new Student { FirstName = "Jon", LastName = "Snow", Year = 2, HasAPartTimeJob = false, Age = 20, FacultyId = "1" };
            _students.Contains(s1);

            // SequenceEqual
        }

        public static void Projection()
        {
            // Select (anonymus types)
            var firstNames = _students.Select(x => x.FirstName);
            PrintCollection(firstNames);

            // SelectMany
            var allStudents = _faculties.SelectMany(x => x.Students);
        }

        public static void Grouping()
        {
            // GroupBy
            var grupedStudents = _students.GroupBy(x => x.Year);

            foreach (var year in grupedStudents)
            {
                Console.WriteLine(year.Key);
                foreach (var student in year)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public static void Generation()
        {
            // DefaultIfEmpty

            // Empty

            // Range

            // Repeat
        }

        public static void ElementOperators()
        {
            // First, FirstOrDefault

            // Last, LastOrDefault

            // Single, SingleOrDefault

            // ElementAt, ElementAtOrDefault
        }

        public static void DataConversion()
        {
            // Cast (throws InvalidCastException if unable to cast an item in the collection)

            // ToDictionary (simply by a key or with element selector)

            // ToLookup
        }

        public static void Aggregation()
        {
            // Aggregate
            var allNames = _students.Aggregate("", (previewsResult, student) => previewsResult + student.FirstName, allNames => allNames);

            // Average

            // Count, LongCount

            // Max, MaxBy

            // Min, MinBy

            // Sum
        }

        public static void SetOperations()
        {
            // Distinct, DistinctBy

            // Except, ExeceptBy

            // Intersect, IntersectBy

            // Union, UnionBy (distinct union)

            // Concat (non distinct)
        }

        public static void Joins()
        {
            // Join (aslo with query language)
            //var facultiesByStudent = _students.Join(
            //    _faculties,
            //    student => student.FacultyId,
            //    faculty => faculty.Id,
            //    (student, faculty) => new { student.FirstName, faculty.Name }
            //    );

            var facultiesByStudent = from student in _students
                                     join faculty in _faculties on student.FacultyId equals faculty.Id
                                     select new { student.FirstName, faculty.Name };

            PrintCollection(facultiesByStudent);

            // GroupJoin
            var studentsByFaculty = from faculty in _faculties
                                    join student in _students on faculty.Id equals student.FacultyId into studentsGroup
                                    select new { faculty.Name, studentsGroup };

            foreach (var studentGroup in studentsByFaculty)
            {
                Console.WriteLine(studentGroup.Name);
                foreach (var student in studentGroup.studentsGroup)
                {
                    Console.WriteLine(student);
                }

            }

            // Zip
        }

        private static readonly IEnumerable<Student> _students = CreateStudentsList();
        private static IEnumerable<Student> CreateStudentsList()
        {
            return new List<Student>
            {
                new Student { FirstName = "Jon", LastName = "Snow", Year = 2, HasAPartTimeJob = false, Age = 20, FacultyId = "1"},
                new Student { FirstName = "Mark", LastName = "Twain", Year = 2, HasAPartTimeJob = false , Age = 21, FacultyId = "1"},
                new Student { FirstName = "Cristiano", LastName = "Ronaldo", Year = 3, HasAPartTimeJob = false, Age = 21 , FacultyId = "4"},
                new Student { FirstName = "Steve", LastName = "Jobs", Year = 4, HasAPartTimeJob = true, Age = 18, FacultyId = "3" },
                new Student { FirstName = "Adam", LastName = "Einstein", Year = 2, HasAPartTimeJob = true, Age = 19, FacultyId = "3"},
                new Student { FirstName = "Maia", LastName = "Sandu", Year = 2, HasAPartTimeJob = true , Age = 24, FacultyId = "2"},
                new HomeStudent { FirstName = "Adam", LastName = "Gontier", Year = 3, HasAPartTimeJob = false, Address = "Selimbar, Sibiu, Ana Aslan 11", Age = 29, FacultyId = "1"},
                new HomeStudent { FirstName = "Bill", LastName = "Gates", Year = 3, HasAPartTimeJob = false, Address = "Timisoara, Strada Victoria", Age = 19, FacultyId = "5"},
                new Student { FirstName = "Winston", LastName = "Churchill", Year = 1, HasAPartTimeJob = true, Age = 30 , FacultyId = "4"},
                new Student { FirstName = "Matei", LastName = "Basarab", Year = 1, HasAPartTimeJob = false , Age = 22, FacultyId = "5"},
                new Student { FirstName = "Radu", LastName = "Stati", Year = 2, HasAPartTimeJob = true , Age = 25, FacultyId = "2"},
            };
        }

        private static readonly IEnumerable<Faculty> _faculties = CreateFacultiesList();
        private static IEnumerable<Faculty> CreateFacultiesList()
        {
            return new List<Faculty>
            {
                new Faculty { Name = "IT", Id = "1", HeadMaster = "Mike Tyson",
                    Students = new List<Student> { new Student() { FirstName = "s1" }, new Student { FirstName = "s2"} } },
                new Faculty { Name = "Marketing", Id = "2", HeadMaster = "Jonas Renkse",
                    Students = new List<Student> { new Student() { FirstName = "s3" }, new Student { FirstName = "s4"} } },
                new Faculty { Name = "Economy", Id = "3", HeadMaster = "Mark Zukerberg",
                    Students = new List<Student> { new Student() { FirstName = "s5" }, new Student { FirstName = "s6"} }},
                new Faculty { Name = "Math", Id = "4", HeadMaster = "Alfred Nobel" },
                new Faculty { Name = "Agriculture", Id = "5", HeadMaster = "Ned Stark" },
            };
        }
    }
}
