namespace MTFUtility
{
    public class Test
    {

    }

    #region Person

    public class Person
    {
        public Levels Level { get; set; }

        public enum Levels
        {
            classE = 0,
            classD = 1,
            Level0 = 2,
            Level1 = 3,
            Level2 = 4,
            Level3 = 5,
            Level4 = 6,
            Level5 = 7
        }

        public Person(Levels level) => Level = level;

        //public static Person GetPerson(Department department, Levels level, object? rank = null)
        //{
        //    int rankNum = rank is int ? (int)rank : 0;

        //    return department switch
        //    {
        //        Department.Science => new Scientist(level, rankNum),
        //        //Department.SRU          => new SRU(),
        //        Department.Engineering => new Engineer(level, rankNum),
        //        //Department.MTF          => new MTF(),
        //        //Department.Medical      => new Medical(),
        //        //Department.DEA          => new DEA(),
        //        //Department.EC           => new EC(),
        //        _ => new Person(level, rankNum)
        //    };
        //}
    }

    public class Scientist : Person
    {
        public ScienceRank Rank { get; set; }

        public enum ScienceRank
        {
            Entrant = 0,
            JrResearcher = 1,
            IntResearcher = 2,
            AssocResearcher = 3,
            Researcher = 4,
            SnrResearcher = 5,
            ChfResearcher = 6,
            Overseer = 7
        }

        public Scientist(Levels level, ScienceRank rank = 0) : base(level) => Rank = rank;
    }

    public class Engineer : Person
    {
        public EngineeringRank Rank { get; set; }

        public enum EngineeringRank
        {
            ApprTechnician = 0,
            Technician = 1,
            AdvTechnician = 2,
            Engineer = 3,
            SrEngineer = 4,
            LeadEngineer = 5,
            Overseer = 6
        }

        public Engineer(Levels level, EngineeringRank rank) : base(level) => Rank = rank;
    }

    public class Security : Person
    {
        public SecurityRank Rank { get; set; }

        public enum SecurityRank
        {
            Trainee = 0,
            Junior = 1,
            Guard = 2,
            Senior = 3,
            Lieutenant = 4,
            Captain = 5,
            Overseer = 6
        }

        public Security(Levels level, SecurityRank rank) : base(level) => Rank = rank;
    }

    public class SRU : Person
    {
        public SRURank Rank { get; set; }

        public enum SRURank
        {
            Recruit = 0,
            Agent = 1,
            Specialist = 2,
            Brigadier = 3,
            Captain = 4,
            Overseer = 5
        }

        public SRU(Levels level, SRURank rank) : base(level) => Rank = rank;
    }

    public class MTF : Person
    {
        public MTFRank Rank { get; set; }

        public enum MTFRank
        {
            Trainee = 0,
            Operative = 1,
            Elite = 2,
            Sergeant = 3,
            Executive = 4,
            Captain = 5,
            Chief = 6,
            Overseer = 7
        }

        public MTF(Levels level, MTFRank rank) : base(level) => Rank = rank;
    }

    public class Medical : Person
    {
        public MedicalRank Rank { get; set; }

        public enum MedicalRank
        {
            Trial = 0,
            Nurse = 1,
            Practitioner = 2,
            Resident = 3,
            Physician = 4,
            Principal = 5,
            Specialist = 6,
            SpecialistInCharge = 7,
            Overseer = 8
        }

        public Medical(Levels level, MedicalRank rank) : base(level) => Rank = rank;
    }

    public class DEA : Person
    {
        public DEARank Rank { get; set; }

        public enum DEARank
        {
            Associate = 0,
            Intern = 1,
            Representative = 2,
            Counsellor = 3,
            Ambassador = 4,
            Director = 5,
            Overseer = 6
        }

        public DEA(Levels level, DEARank rank) : base(level) => Rank = rank;
    }

    public class EC : Person
    {
        public ECRank Rank { get; set; }

        public enum ECRank
        {
            Probationary = 0,
            Committee = 1,
            SeniorCommittee = 2,
            RegulatoryInspector = 3,
            Editor = 4,
            Overseer = 5,
        }

        public EC(Levels level, ECRank rank) : base(level) => Rank = rank;
    }

    #endregion

}