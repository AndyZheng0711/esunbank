USE [esunbank]
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_t187ap05_L]    Script Date: 2024/9/12 �U�� 01:17:04 ******/
DROP PROCEDURE [dbo].[SP_GET_t187ap05_L]
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_t187ap05_L]    Script Date: 2024/9/12 �U�� 01:17:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GET_t187ap05_L]
	@���q�N�� int,
	@���q�W�� nvarchar(max),
	@���~�O nvarchar(max)
AS
BEGIN
	SELECT
		�X����,
		��Ʀ~��,
		���q�N��,
		���q�W��,
		���~�O,
		��~���J_����禬,
		��~���J_�W���禬,
		��~���J_�h�~����禬,
		��~���J_�W�����W��,
		��~���J_�h�~�P��W��,
		�֭p��~���J_���֭p�禬,
		�֭p��~���J_�h�~�֭p�禬,
		�֭p��~���J_�e������W��,
		�Ƶ�
	FROM t187ap05_L
	WHERE
		(���q�N�� = @���q�N�� OR @���q�N�� IS NULL OR @���q�N�� = '') and
		(���q�W�� like '%' + @���q�W�� + '%' OR @���q�W�� IS NULL OR @���q�W�� = '') and
		(���~�O like '%' + @���~�O + '%' OR @���~�O IS NULL OR @���~�O = '')
END
GO


