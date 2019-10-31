export class DateHelper {
	public static sqlToJsDate(sqlDate: Date): Date {
		//sqlDate in SQL DATETIME format ("yyyy-mm-ddThh:mm:ss.ms")
		var sqlDateArr1 = sqlDate.toString().split("-");
		console.log(sqlDateArr1);
		//format of sqlDateArr1[] = ['yyyy','mm','dd hh:mm:ms']
		var sYear = isNaN(Number(sqlDateArr1[0])) ? 1900 : Number(sqlDateArr1[0]);
		var sMonth = isNaN(Number(sqlDateArr1[1]) - 1) ? 1 : Number(Number(sqlDateArr1[1]) - 1);
		var sqlDateArr2 = sqlDateArr1[2].split("T");
		//format of sqlDateArr2[] = ['dd', 'hh:mm:ss.ms']
		var sDay = isNaN(Number(sqlDateArr2[0])) ? 1 : Number(sqlDateArr2[0]);

		var sqlDateArr3 = sqlDateArr2[1].split(":");
		//format of sqlDateArr3[] = ['hh','mm','ss.ms']
		var sHour = isNaN(Number(sqlDateArr3[0])) ? 0 : Number(sqlDateArr3[0]);
		var sMinute = Number(sqlDateArr3[1]);
		var sqlDateArr4 = sqlDateArr3[2].split(".");
		//format of sqlDateArr4[] = ['ss','ms']
		var sSecond = isNaN(Number(sqlDateArr4[0])) ? 0 : Number(sqlDateArr4[0]);
		var sMillisecond = isNaN(Number(sqlDateArr4[1])) ? 0 : Number(sqlDateArr4[1]);

		console.log(new Date(sYear, sMonth, sDay, sHour, sMinute, sSecond, sMillisecond));

		return new Date(sYear, sMonth, sDay, sHour, sMinute, sSecond, sMillisecond);
	}

	public static getDateByLocale(date: Date, locale: string): string {
		var options = { year: "numeric", month: "long", day: "numeric" };
		try {
			var parsedDate = DateHelper.sqlToJsDate(date);
			console.log(parsedDate.toLocaleDateString(locale, options));
		} catch (e) {
			console.log(e);
		}
		return parsedDate.toLocaleDateString(locale, options);
	}
}
