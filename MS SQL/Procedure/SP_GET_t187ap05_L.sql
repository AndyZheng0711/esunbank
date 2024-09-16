USE [esunbank]
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_t187ap05_L]    Script Date: 2024/9/12 下午 01:17:04 ******/
DROP PROCEDURE [dbo].[SP_GET_t187ap05_L]
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_t187ap05_L]    Script Date: 2024/9/12 下午 01:17:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GET_t187ap05_L]
	@公司代號 int,
	@公司名稱 nvarchar(max),
	@產業別 nvarchar(max)
AS
BEGIN
	SELECT
		出表日期,
		資料年月,
		公司代號,
		公司名稱,
		產業別,
		營業收入_當月營收,
		營業收入_上月營收,
		營業收入_去年當月營收,
		營業收入_上月比較增減,
		營業收入_去年同月增減,
		累計營業收入_當月累計營收,
		累計營業收入_去年累計營收,
		累計營業收入_前期比較增減,
		備註
	FROM t187ap05_L
	WHERE
		(公司代號 = @公司代號 OR @公司代號 IS NULL OR @公司代號 = '') and
		(公司名稱 like '%' + @公司名稱 + '%' OR @公司名稱 IS NULL OR @公司名稱 = '') and
		(產業別 like '%' + @產業別 + '%' OR @產業別 IS NULL OR @產業別 = '')
END
GO


