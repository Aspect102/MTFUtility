namespace MTFUtility
{
    //ceri test

    class Testing
    {
        
    }

    class Person
    {
        Levels Level { get; set; }
    }
    class Scientist : Person
    {
        ScienceRanks ScienceRank { get; set; }
    }

    class Engineer : Person
    {
        EngineeringRanks EngineeringRank { get; set; }
    }

    //etc..? where do I handle Host Status vs Spectator Status vs Escort Status
    class Host
    {
        Levels Level { get; set; }
    }

    class Escort
    {
        Levels Level { get; set; }
    }

    enum Levels
    {
        ClassE = 0,
        ClassD = 1,
        Level0 = 2,
        Level1 = 3,
        Level2 = 4,
        Level3 = 5,
        Level4 = 6,
        Level5 = 7
    }

    enum ScienceRanks
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

    enum SecurityRanks
    {
        Trainee = 0,
        Junior = 1,
        Guard = 2,
        Senior = 3,
        Lieutenant = 4,
        Captain = 5,
        Overseer = 6
    }
    
    enum SRURanks
    {
        Recruit = 0,
        Agent = 1,
        Specialist = 2,
        Brigadier = 3,
        Captain = 4,
        Overseer = 5
    }

    enum EngineeringRanks
    {
        ApprTechnician = 0,
        Technician = 1,
        AdvTechnician = 2,
        Engineer = 3,
        SrEngineer = 4,
        LeadEngineer = 5,
        Overseer = 6
    }

    enum MTFRanks
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

    enum MedicalRanks
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

    enum DEARanks
    {
        Associate = 0,
        Intern = 1,
        Representative = 2,
        Counsellor = 3,
        Ambassador = 4,
        Director = 5,
        Overseer = 6
    }

    enum ECRanks
    {
        Probationary = 0,
        Committee = 1,
        SeniorCommittee = 2,
        RegulatoryInspector = 3,
        Editor = 4,
        Overseer = 5,
    }
}
