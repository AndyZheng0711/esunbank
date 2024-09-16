USE [esunbank]
GO

/****** Object:  StoredProcedure [dbo].[SP_MOD_t187ap05_L]    Script Date: 2024/9/12 下午 01:20:02 ******/
DROP PROCEDURE [dbo].[SP_MOD_t187ap05_L]
GO

/****** Object:  StoredProcedure [dbo].[SP_MOD_t187ap05_L]    Script Date: 2024/9/12 下午 01:20:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[SP_MOD_t187ap05_L]
    @Type VARCHAR(10),
	@出表日期 int,
	@資料年月 int,
	@公司代號 int,
	@公司名稱 nvarchar(50),
	@產業別 nvarchar(50),
	@營業收入_當月營收 numeric(28,0),
	@營業收入_上月營收 numeric(28,0),
	@營業收入_去年當月營收 numeric(28,0),
	@營業收入_上月比較增減 numeric(28,16),
	@營業收入_去年同月增減 numeric(28,16),
	@累計營業收入_當月累計營收 numeric(28,0),
	@累計營業收入_去年累計營收 numeric(28,0),
	@累計營業收入_前期比較增減 numeric(28,16),
	@備註 nvarchar(1000)
AS
BEGIN
	IF (@Type = 'Insert')
	BEGIN
		INSERT INTO t187ap05_L values (
		@出表日期,
		@資料年月,
		@公司代號,
		@公司名稱,
		@產業別,
		@營業收入_當月營收,
		@營業收入_上月營收,
		@營業收入_去年當月營收,
		@營業收入_上月比較增減,
		@營業收入_去年同月增減,
		@累計營業收入_當月累計營收,
		@累計營業收入_去年累計營收,
		@累計營業收入_前期比較增減,
		@備註)
	END
	IF (@Type = 'Update')
	BEGIN
	Update t187ap05_L Set
		出表日期 = @出表日期,
		資料年月 = @資料年月,
		公司名稱 = @公司名稱,
		產業別 = @產業別,
		營業收入_當月營收 = @營業收入_當月營收,
		營業收入_上月營收 = @營業收入_上月營收,
		營業收入_去年當月營收 = @營業收入_去年當月營收,
		營業收入_上月比較增減 = @營業收入_上月比較增減,
		營業收入_去年同月增減 = @營業收入_去年同月增減,
		累計營業收入_當月累計營收 = @累計營業收入_當月累計營收,
		累計營業收入_去年累計營收 = @累計營業收入_去年累計營收,
		累計營業收入_前期比較增減 = @累計營業收入_前期比較增減,
		備註 = @備註 
	WHERE 公司代號 = @公司代號
	END
END
GO


