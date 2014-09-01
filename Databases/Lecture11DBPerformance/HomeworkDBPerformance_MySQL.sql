CREATE SCHEMA `hwperformancedb` ;
USE `HWPerformanceDB`;

CREATE TABLE `hwperformancedb`.`logs` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `log_text` VARCHAR(100) NULL,
  `log_datetime` TIMESTAMP NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC));

insert into `hwperformancedb`.`logs` (`log_text`,`log_datetime`) VALUE ('text1',DATE(NOW()));
insert into `hwperformancedb`.`logs` (`log_text`,`log_datetime`) VALUE ('text2',DATE(NOW()-INTERVAL 5 Year));
insert into `hwperformancedb`.`logs` (`log_text`,`log_datetime`) VALUE ('text3',DATE(NOW()-INTERVAL 10 Year));
insert into `hwperformancedb`.`logs` (`log_text`,`log_datetime`) VALUE ('text4',DATE(NOW()-INTERVAL 15 Year));
insert into `hwperformancedb`.`logs` (`log_text`,`log_datetime`) VALUE ('text5',DATE(NOW()-INTERVAL 20 Year));

-- need to run it few times to populate table
insert into `hwperformancedb`.`logs` (`log_text`,`log_datetime`)
		SELECT `log_text` , `log_datetime` FROM `logs`;

-- For some reason the procedure doesnt work on my pc even tough it's correct. I get errors on While statment
/*

CREATE PROCEDURE `populate_logs`()
BEGIN
WHILE ((SELECT COUNT(*) FROM `hwperformancedb`.`logs`) < 1000000 ) DO
		insert into `hwperformancedb`.`logs` (`log_text`,`log_datetime`)
		SELECT `log_text` , `log_datetime` FROM `logs`
END WHILE;
COMMIT;
END;


CALL `populate_logs`
*/
ALTER TABLE `hwperformancedb`.`logs` 
 PARTITION BY RANGE(YEAR(log_datetime)) PARTITIONS 5( PARTITION part0 VALUES LESS THAN (1995),  PARTITION part1 VALUES LESS THAN (2000),  PARTITION part2 VALUES LESS THAN (2005),  PARTITION part3 VALUES LESS THAN (2010),  PARTITION part4 VALUES LESS THAN (2015));
