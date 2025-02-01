CREATE TABLE Teacher (
    TeacherID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Gender NVARCHAR(10),
    Subject NVARCHAR(50)
);

 CREATE TABLE Pupil (
    PupilID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Gender NVARCHAR(10),
    Class NVARCHAR(10)
);

CREATE TABLE TeacherPupil (
    TeacherID INT,
    PupilID INT,
    PRIMARY KEY (TeacherID, PupilID),
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
    FOREIGN KEY (PupilID) REFERENCES Pupil(PupilID)
);