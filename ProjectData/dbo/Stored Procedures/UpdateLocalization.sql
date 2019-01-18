CREATE PROCEDURE UpdateLocalization 
	@jsonLocalization NVARCHAR(MAX)
AS
BEGIN
	Insert into LocalizationLanguage(LocalizationKey,LocalizationValue,LocalizationLanguage)
	SELECT LocalizationKey,LocalizationValue,LocalizationLanguage FROM OPENJSON ( @jsonLocalization )  
	WITH (   
			LocalizationKey   varchar(500) '$.LocalizationKey' ,  
			LocalizationValue     varchar(max)     '$.LocalizationValue',  
			LocalizationLanguage varchar(10) '$.LocalizationLanguage'
	 )
	END
	select COUNT(1)