CREATE PROCEDURE GetAllLocalization
	@pageSize int,
	@pageNumber int,
	@total int out
AS
BEGIN
	select * from LocalizationLanguage
	ORDER BY LocalizationKey
	OFFSET @PageSize * (@PageNumber - 1) ROWS
    FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE);

	SET @total = (SELECT COUNT(*) FROM LocalizationLanguage)
END