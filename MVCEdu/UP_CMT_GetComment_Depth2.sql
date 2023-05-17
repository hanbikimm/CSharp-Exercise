CREATE PROCEDURE [dbo].[UP_CMT_GetComment_Depth2]  
(
	@Req_Depth int = 2,
	@Req_Parent_ID int = 0
)

AS
BEGIN

WITH CTE_CMT (Parent_ID, ID, Depth, Writer, Content, Relation)
	AS (
	SELECT Parent_ID, ID, Depth, Writer, Content, CONVERT(VARCHAR(20), FORMAT(ID, '00000')) AS Relation
		FROM Comment
		WHERE Parent_ID = @Req_Parent_ID AND Depth = 1

	UNION ALL

	SELECT A.Parent_ID, A.ID, A.Depth, A.Writer, A.Content, CONVERT(VARCHAR(20), CONCAT(FORMAT(C.ID,'00000'), '-', FORMAT(A.ID, '00000'))) AS Relation
		FROM Comment AS A
		INNER JOIN CTE_CMT AS C ON A.Parent_ID = C.ID AND A.Depth = @Req_Depth
	)
SELECT * 
	FROM CTE_CMT
	ORDER BY Relation ASC, ID ASC

END