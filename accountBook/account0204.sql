-- --------------------------------------------------------
-- 호스트:                          127.0.0.1
-- 서버 버전:                        10.1.28-MariaDB - mariadb.org binary distribution
-- 서버 OS:                        Win32
-- HeidiSQL 버전:                  11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- 테이블 dawoon.dc_account 구조 내보내기
DROP TABLE IF EXISTS `dc_account`;
CREATE TABLE IF NOT EXISTS `dc_account` (
  `accSeq` int(11) NOT NULL COMMENT '번호',
  `usedDate` varchar(60) DEFAULT NULL COMMENT '달력',
  `accAcount` varchar(20) DEFAULT NULL COMMENT '지출수입',
  `itemSeq` int(11) DEFAULT NULL COMMENT 'dc_items의 고유번호',
  `subject` varchar(20) DEFAULT NULL,
  `money` varchar(20) DEFAULT NULL COMMENT '돈',
  `content` varchar(50) DEFAULT NULL,
  `memo` varchar(20) DEFAULT NULL COMMENT '사유',
  `flagYN` varchar(1) DEFAULT 'Y' COMMENT '가용여부(Y:유효/N:삭제)',
  `regDate` datetime DEFAULT NULL COMMENT '최초저장일',
  `issueDate` datetime DEFAULT NULL COMMENT '최종저장일',
  `issueID` varchar(20) DEFAULT '' COMMENT '최종저장자 ID',
  PRIMARY KEY (`accSeq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='사용자 관리';

-- 테이블 데이터 dawoon.dc_account:~11 rows (대략적) 내보내기
DELETE FROM `dc_account`;
/*!40000 ALTER TABLE `dc_account` DISABLE KEYS */;
/*!40000 ALTER TABLE `dc_account` ENABLE KEYS */;

-- 테이블 dawoon.dc_items 구조 내보내기
DROP TABLE IF EXISTS `dc_items`;
CREATE TABLE IF NOT EXISTS `dc_items` (
  `itemSeq` int(11) NOT NULL COMMENT '아이템번호',
  `acount` varchar(20) DEFAULT '' COMMENT '입금출금',
  `subject` varchar(20) NOT NULL DEFAULT '' COMMENT '월급,이자,상여금,보너스',
  `flagYN` varchar(1) DEFAULT 'Y' COMMENT '가용여부(Y:유효/N:삭제)',
  `regDate` datetime DEFAULT NULL COMMENT '최초저장일',
  `issueDate` datetime DEFAULT NULL COMMENT '최종저장일',
  `issueID` varchar(20) DEFAULT '' COMMENT '최종저장자 ID',
  PRIMARY KEY (`itemSeq`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='사용자 관리';

-- 테이블 데이터 dawoon.dc_items:~8 rows (대략적) 내보내기
DELETE FROM `dc_items`;
/*!40000 ALTER TABLE `dc_items` DISABLE KEYS */;
INSERT INTO `dc_items` (`itemSeq`, `acount`, `subject`, `flagYN`, `regDate`, `issueDate`, `issueID`) VALUES
	(0, '지출', '과자', 'Y', '2022-02-04 18:48:39', '2022-02-04 18:48:39', 'CDY'),
	(2, '지출', '과자2', 'Y', '2022-02-04 18:49:00', '2022-02-04 18:49:00', 'CDY'),
	(3, '지출', '과자3', 'Y', '2022-02-04 18:49:05', '2022-02-04 18:49:05', 'CDY'),
	(4, '지출', '용돈', 'Y', '2022-02-04 18:49:18', '2022-02-04 18:49:18', 'CDY'),
	(5, '지출', '월급', 'Y', '2022-02-04 18:49:25', '2022-02-04 18:49:25', 'CDY'),
	(6, '수입', '월급', 'N', '2022-02-04 18:49:34', '2022-02-04 18:49:34', 'CDY'),
	(7, '수입', '떡값', 'Y', '2022-02-04 18:49:47', '2022-02-04 18:49:47', 'CDY'),
	(8, '지출', '점심', 'Y', '2022-02-04 18:50:48', '2022-02-04 18:50:48', 'CDY'),
	(9, '지출', '치킨', 'Y', '2022-02-04 18:50:52', '2022-02-04 18:50:52', 'CDY');
/*!40000 ALTER TABLE `dc_items` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
