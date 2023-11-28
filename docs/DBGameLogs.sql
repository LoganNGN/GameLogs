-- MySQL Script generated by MySQL Workbench
-- Mon Nov 27 11:57:45 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Game`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Game` (
  `idGame` INT NOT NULL,
  `name` VARCHAR(85) NOT NULL,
  `description` VARCHAR(500) NULL,
  `gameState` TINYINT NOT NULL,
  `image` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`idGame`),
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE,
  UNIQUE INDEX `idGame_UNIQUE` (`idGame` ASC) VISIBLE)
ENGINE = InnoDB;

CREATE USER 'UserGameLogs' IDENTIFIED BY 'Pa$$W0rd';

GRANT SELECT ON TABLE `mydb`.* TO 'DBGameLogs';
GRANT SELECT, INSERT, UPDATE, DELETE ON TABLE `mydb`.* TO 'DBGameLogs';



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
