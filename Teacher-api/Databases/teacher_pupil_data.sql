
INSERT INTO Teacher (FirstName, LastName, Gender, Subject)
VALUES 
('David', 'Smith', 'Male', 'Math'),
('Sophia', 'Johnson', 'Female', 'English'),
('Michael', 'Brown', 'Male', 'Science');


INSERT INTO Pupil (FirstName, LastName, Gender, Class)
VALUES 
('გიორგი', 'აბაშიძე', 'Male', 'A1'),
('ანა', 'გელაშვილი', 'Female', 'B1'),
('გიორგი', 'ბერიძე', 'Male', 'A2'),
('ნიკოლოზ', 'მათიკაშვილი', 'Male', 'B2');


INSERT INTO TeacherPupil (TeacherID, PupilID)
VALUES 
(1, 1),  
(1, 2),  
(2, 3), 
(3, 4);  
