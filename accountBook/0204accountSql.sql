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

-- 테이블 데이터 dawoon.dc_account:~2 rows (대략적) 내보내기
DELETE FROM `dc_account`;
/*!40000 ALTER TABLE `dc_account` DISABLE KEYS */;
INSERT INTO `dc_account` (`accSeq`, `usedDate`, `accAcount`, `itemSeq`, `subject`, `money`, `content`, `memo`, `flagYN`, `regDate`, `issueDate`, `issueID`) VALUES
	(0, '2022-01-28', '지출', 1, '간식', '5,000', '55', '555', 'N', '2022-02-04 17:47:25', '2022-02-04 17:47:25', 'CDY'),
	(1, '2022-02-04', '수입', 2, '용돈', '3', '48484', '2', 'Y', '2022-02-04 17:47:42', '2022-02-04 17:47:42', 'CDY'),
	(2, '2022-01-28', '지출', 0, '월급', '50,000', '점심값들어옴', '점심먹었을때 나온 돈 기업은행으로 들', 'N', '2022-02-04 18:08:24', '2022-02-04 18:08:24', 'CDY'),
	(3, '2022-01-28', '지출', 3, '구매', '10,404', '헤드폰', '쇼핑몰', 'Y', '2022-02-04 18:08:57', '2022-02-04 18:08:57', 'CDY'),
	(4, '2022-02-04', '지출', 3, '구매', '848,484', '48484', '2', 'Y', '2022-02-04 18:09:12', '2022-02-04 18:09:12', 'CDY'),
	(5, '2022-01-28', '수입', 2, '월급', '5', '11', '11', 'Y', '2022-02-04 18:13:02', '2022-02-04 18:13:02', 'CDY'),
	(6, '2022-01-28', '수입', 2, '월급', '3,333', '1', '22', 'Y', '2022-02-04 18:13:11', '2022-02-04 18:13:11', 'CDY'),
	(7, '2022-01-28', '지출', 1, '간식', '4,545', '4545', '4545', 'Y', '2022-02-04 18:13:46', '2022-02-04 18:13:46', 'CDY'),
	(8, '2022-01-28', '지출', 1, '간식', '5,050', '5050', '5050', 'Y', '2022-02-04 18:13:55', '2022-02-04 18:13:55', 'CDY'),
	(9, '2022-01-28', '지출', 1, '간식', '40,545', '454545', '4545', 'Y', '2022-02-04 18:14:01', '2022-02-04 18:14:01', 'CDY'),
	(10, '2022-01-28', '지출', 8, '간식2', '23,232', '2222', '113232', 'Y', '2022-02-04 18:14:10', '2022-02-04 18:14:10', 'CDY');
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

-- 테이블 데이터 dawoon.dc_items:~2 rows (대략적) 내보내기
DELETE FROM `dc_items`;
/*!40000 ALTER TABLE `dc_items` DISABLE KEYS */;
INSERT INTO `dc_items` (`itemSeq`, `acount`, `subject`, `flagYN`, `regDate`, `issueDate`, `issueID`) VALUES
	(1, '지출', '저녁식대', 'Y', '2022-02-04 17:45:37', '2022-02-04 17:45:38', 'CDY'),
	(2, '지출', '월급', 'Y', '2022-02-04 17:46:37', '2022-02-04 17:46:37', 'CDY'),
	(3, '지출', '월급', 'Y', '2022-02-04 17:52:28', '2022-02-04 17:52:28', 'CDY'),
	(4, '지출', '점심식대', 'Y', '2022-02-04 18:05:28', '2022-02-04 18:05:28', 'CDY'),
	(5, '지출', '저녁식대', 'Y', '2022-02-04 18:05:44', '2022-02-04 18:05:44', 'CDY'),
	(6, '지출', '월급', 'Y', '2022-02-04 18:05:58', '2022-02-04 18:05:58', 'CDY'),
	(7, '수입', '급여', 'N', '2022-02-04 18:06:03', '2022-02-04 18:06:03', 'CDY'),
	(8, '지출', '저녁식대', 'Y', '2022-02-04 18:06:16', '2022-02-04 18:06:16', 'CDY');
/*!40000 ALTER TABLE `dc_items` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
