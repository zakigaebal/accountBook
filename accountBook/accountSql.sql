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
  `accSeq` int(11) DEFAULT NULL COMMENT '번호',
  `usedDate` varchar(20) DEFAULT NULL COMMENT '달력',
  `accAcount` varchar(20) DEFAULT NULL COMMENT '지출수입',
  `itemSeq` int(11) DEFAULT NULL COMMENT 'dc_items의 고유번호',
  `subject` varchar(20) DEFAULT NULL,
  `money` varchar(20) DEFAULT NULL COMMENT '돈',
  `content` varchar(50) DEFAULT NULL,
  `memo` varchar(20) DEFAULT NULL COMMENT '사유',
  `flagYN` varchar(1) DEFAULT 'Y' COMMENT '가용여부(Y:유효/N:삭제)',
  `regDate` datetime DEFAULT NULL COMMENT '최초저장일',
  `issueDate` datetime DEFAULT NULL COMMENT '최종저장일',
  `issueID` varchar(20) DEFAULT '' COMMENT '최종저장자 ID'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='사용자 관리';

-- 테이블 데이터 dawoon.dc_account:~15 rows (대략적) 내보내기
DELETE FROM `dc_account`;
/*!40000 ALTER TABLE `dc_account` DISABLE KEYS */;
INSERT INTO `dc_account` (`accSeq`, `usedDate`, `accAcount`, `itemSeq`, `subject`, `money`, `content`, `memo`, `flagYN`, `regDate`, `issueDate`, `issueID`) VALUES
	(34, '2022년 1월 27일 목요일', '수입', 16, '월급', '5000000', '급여', '급여입니다', 'Y', '2022-01-27 13:58:37', '2022-01-27 13:58:37', 'CDY'),
	(35, '2022년 1월 27일 목요일', '수입', 15, '용돈', '30000', '짬뽕', '둘이서', 'Y', '2022-01-27 14:01:35', '2022-01-27 14:01:35', 'CDY'),
	(36, '2022년 1월 27일 목요일', '지출', 15, '용돈', '10000', '짜장', '혼자서', 'Y', '2022-01-27 14:01:45', '2022-01-27 14:01:45', 'CDY'),
	(37, '2022년 1월 27일 목요일', '지출', 13, '식대', '1', '1', '1', 'N', '2022-01-27 14:53:56', '2022-01-27 14:53:56', 'CDY'),
	(38, '2022년 1월 27일 목요일', '수입', 15, '용돈', '1', '11', '111', 'N', '2022-01-27 15:17:15', '2022-01-27 15:17:15', 'CDY'),
	(39, '2022년 1월 27일 목요일', '수입', 15, '용돈', '22', '22', '22', 'N', '2022-01-27 15:17:24', '2022-01-27 15:17:24', 'CDY'),
	(40, '2022년 1월 27일 목요일', '지출', 23, 'ㅁ', '2', 'ㅁ', '2', 'N', '2022-01-27 15:39:48', '2022-01-27 15:39:48', 'CDY'),
	(41, '2022년 1월 27일 목요일', '지출', 23, 'ㅁ', '3', '3', '3', 'N', '2022-01-27 15:40:30', '2022-01-27 15:40:30', 'CDY'),
	(42, '2022년 1월 27일 목요일', '지출', 24, '밥', '50000', '0', '1', 'Y', '2022-01-27 15:41:53', '2022-01-27 15:41:53', 'CDY'),
	(43, '2022년 1월 27일 목요일', '지출', 25, '국', '5000', '500', '', 'Y', '2022-01-27 15:42:53', '2022-01-27 15:42:53', 'CDY'),
	(44, '2022년 1월 27일 목요일', '수입', 16, '월급', '20000000', '급여', '2백만원', 'Y', '2022-01-27 15:59:21', '2022-01-27 15:59:21', 'CDY'),
	(45, '2022년 1월 27일 목요일', '수입', 0, '용돈', '500001', '생일선물', '용돈 5만원', 'Y', '2022-01-27 16:00:05', '2022-01-27 16:00:05', 'CDY'),
	(46, '2022년 1월 27일 목요일', '지출', 18, '간식', '2000', '간식 2000원', '과자봉지 2개', 'Y', '2022-01-27 16:00:40', '2022-01-27 16:00:40', 'CDY'),
	(47, '2022년 1월 27일 목요일', '수입', 16, '월급', '122222', '22', '22', 'N', '2022-01-27 16:06:33', '2022-01-27 16:06:33', 'CDY'),
	(48, '2022년 1월 27일 목요일', '지출', 0, '월급', '200000001', '급여', '2백만원', 'Y', '2022-01-27 16:26:48', '2022-01-27 16:26:48', 'CDY'),
	(49, '2022년 1월 27일 목요일', '지출', 13, '식대', '20000', '차돌짬뽕', '짬뽕먹기', 'Y', '2022-01-27 16:32:00', '2022-01-27 16:32:00', 'CDY');
/*!40000 ALTER TABLE `dc_account` ENABLE KEYS */;

-- 테이블 dawoon.dc_items 구조 내보내기
DROP TABLE IF EXISTS `dc_items`;
CREATE TABLE IF NOT EXISTS `dc_items` (
  `itemSeq` int(11) DEFAULT NULL COMMENT '아이템번호',
  `acount` varchar(20) DEFAULT '' COMMENT '입금출금',
  `subject` varchar(20) NOT NULL DEFAULT '' COMMENT '월급,이자,상여금,보너스',
  `flagYN` varchar(1) DEFAULT 'Y' COMMENT '가용여부(Y:유효/N:삭제)',
  `regDate` datetime DEFAULT NULL COMMENT '최초저장일',
  `issueDate` datetime DEFAULT NULL COMMENT '최종저장일',
  `issueID` varchar(20) DEFAULT '' COMMENT '최종저장자 ID',
  PRIMARY KEY (`subject`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='사용자 관리';

-- 테이블 데이터 dawoon.dc_items:~12 rows (대략적) 내보내기
DELETE FROM `dc_items`;
/*!40000 ALTER TABLE `dc_items` DISABLE KEYS */;
INSERT INTO `dc_items` (`itemSeq`, `acount`, `subject`, `flagYN`, `regDate`, `issueDate`, `issueID`) VALUES
	(23, '지출', 'ㅁ', 'Y', '2022-01-27 15:39:18', '2022-01-27 15:39:18', 'CDY'),
	(18, '지출', '간식', 'Y', '2022-01-26 21:29:17', '2022-01-26 21:29:17', 'CDY'),
	(20, '지출', '교육비', 'Y', '2022-01-26 21:29:31', '2022-01-26 21:29:31', 'CDY'),
	(14, '지출', '구매', 'Y', '2022-01-26 16:44:08', '2022-01-26 16:44:08', 'CDY'),
	(25, '지출', '국', 'Y', '2022-01-27 15:42:40', '2022-01-27 15:42:40', 'CDY'),
	(22, '지출', '군것질', 'Y', '2022-01-27 15:11:09', '2022-01-27 15:11:09', 'CDY'),
	(24, '지출', '밥', 'Y', '2022-01-27 15:41:41', '2022-01-27 15:41:41', 'CDY'),
	(17, '지출', '보너스', 'Y', '2022-01-26 19:17:22', '2022-01-26 19:17:23', 'CDY'),
	(13, '지출', '식대', 'Y', '2022-01-26 14:08:21', '2022-01-26 14:08:21', 'CDY'),
	(15, '지출', '용돈', 'Y', '2022-01-26 19:11:48', '2022-01-26 19:11:48', 'CDY'),
	(16, '지출', '월급', 'Y', '2022-01-26 19:16:59', '2022-01-26 19:16:59', 'CDY'),
	(21, '지출', '점심식대', 'Y', '2022-01-27 12:02:12', '2022-01-27 12:02:12', 'CDY'),
	(19, '지출', '플렉스', 'Y', '2022-01-26 21:29:26', '2022-01-26 21:29:26', 'CDY');
/*!40000 ALTER TABLE `dc_items` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
