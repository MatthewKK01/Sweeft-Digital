SELECT DISTINCT *
FROM Teacher T
WHERE EXISTS (
    SELECT 1 
    FROM TeacherPupil TP
    WHERE TP.TeacherID = T.TeacherID 
    AND EXISTS (
        SELECT 1 
        FROM Pupil P
        WHERE P.PupilID = TP.PupilID
        AND P.FirstName = 'გიორგი'
    )
);
