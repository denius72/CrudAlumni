-- Total de alunos cadastrados
SELECT COUNT(*) AS TotalAlunos FROM Aluno;

-- Total de alunos por série
SELECT Serie, COUNT(*) AS TotalPorSerie
FROM Aluno
GROUP BY Serie
ORDER BY Serie;

-- Total de alunos por segmento
SELECT Segmento, COUNT(*) AS TotalPorSegmento
FROM Aluno
GROUP BY Segmento;

-- Quantidade e segmento de alunos entre 4 e 8
SELECT Segmento, COUNT(*) AS TotalEntre4e8Anos
FROM Aluno
WHERE 
  DATEDIFF(YEAR, DataNascimento, GETDATE()) 
  - CASE 
      WHEN MONTH(DataNascimento) >= MONTH(GETDATE()) AND DAY(DataNascimento) > DAY(GETDATE())
      THEN 1 
      ELSE 0 
    END 
  BETWEEN 4 AND 8
GROUP BY Segmento;


-- Irmãos com mesmo nome do Pai
SELECT NomePai AS NomeResponsavel, COUNT(*) AS Quantidade, STRING_AGG(Nome, ', ') AS Irmaos
FROM Aluno
GROUP BY NomePai
HAVING COUNT(*) > 1