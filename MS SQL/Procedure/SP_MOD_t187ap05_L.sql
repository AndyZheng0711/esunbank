USE [esunbank]
GO

/****** Object:  StoredProcedure [dbo].[SP_MOD_t187ap05_L]    Script Date: 2024/9/12 �U�� 01:20:02 ******/
DROP PROCEDURE [dbo].[SP_MOD_t187ap05_L]
GO

/****** Object:  StoredProcedure [dbo].[SP_MOD_t187ap05_L]    Script Date: 2024/9/12 �U�� 01:20:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[SP_MOD_t187ap05_L]
    @Type VARCHAR(10),
	@�X���� int,
	@��Ʀ~�� int,
	@���q�N�� int,
	@���q�W�� nvarchar(50),
	@���~�O nvarchar(50),
	@��~���J_����禬 numeric(28,0),
	@��~���J_�W���禬 numeric(28,0),
	@��~���J_�h�~����禬 numeric(28,0),
	@��~���J_�W�����W�� numeric(28,16),
	@��~���J_�h�~�P��W�� numeric(28,16),
	@�֭p��~���J_���֭p�禬 numeric(28,0),
	@�֭p��~���J_�h�~�֭p�禬 numeric(28,0),
	@�֭p��~���J_�e������W�� numeric(28,16),
	@�Ƶ� nvarchar(1000)
AS
BEGIN
	IF (@Type = 'Insert')
	BEGIN
		INSERT INTO t187ap05_L values (
		@�X����,
		@��Ʀ~��,
		@���q�N��,
		@���q�W��,
		@���~�O,
		@��~���J_����禬,
		@��~���J_�W���禬,
		@��~���J_�h�~����禬,
		@��~���J_�W�����W��,
		@��~���J_�h�~�P��W��,
		@�֭p��~���J_���֭p�禬,
		@�֭p��~���J_�h�~�֭p�禬,
		@�֭p��~���J_�e������W��,
		@�Ƶ�)
	END
	IF (@Type = 'Update')
	BEGIN
	Update t187ap05_L Set
		�X���� = @�X����,
		��Ʀ~�� = @��Ʀ~��,
		���q�W�� = @���q�W��,
		���~�O = @���~�O,
		��~���J_����禬 = @��~���J_����禬,
		��~���J_�W���禬 = @��~���J_�W���禬,
		��~���J_�h�~����禬 = @��~���J_�h�~����禬,
		��~���J_�W�����W�� = @��~���J_�W�����W��,
		��~���J_�h�~�P��W�� = @��~���J_�h�~�P��W��,
		�֭p��~���J_���֭p�禬 = @�֭p��~���J_���֭p�禬,
		�֭p��~���J_�h�~�֭p�禬 = @�֭p��~���J_�h�~�֭p�禬,
		�֭p��~���J_�e������W�� = @�֭p��~���J_�e������W��,
		�Ƶ� = @�Ƶ� 
	WHERE ���q�N�� = @���q�N��
	END
END
GO


