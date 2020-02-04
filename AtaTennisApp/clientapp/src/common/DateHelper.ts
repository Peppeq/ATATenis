export class DateHelper {
  public static sqlToJsDate(sqlDate: Date): Date {
    // sqlDate in SQL DATETIME format ("yyyy-mm-ddThh:mm:ss.ms")
    const sqlDateArr1 = sqlDate.toString().split("-");
    console.log(sqlDateArr1);
    // format of sqlDateArr1[] = ['yyyy','mm','dd hh:mm:ms']
    const sYear = isNaN(Number(sqlDateArr1[0])) ? 1900 : Number(sqlDateArr1[0]);
    const sMonth = isNaN(Number(sqlDateArr1[1]) - 1) ? 1 : Number(Number(sqlDateArr1[1]) - 1);
    const sqlDateArr2 = sqlDateArr1[2].split("T");
    // format of sqlDateArr2[] = ['dd', 'hh:mm:ss.ms']
    const sDay = isNaN(Number(sqlDateArr2[0])) ? 1 : Number(sqlDateArr2[0]);

    const sqlDateArr3 = sqlDateArr2[1].split(":");
    // format of sqlDateArr3[] = ['hh','mm','ss.ms']
    const sHour = isNaN(Number(sqlDateArr3[0])) ? 0 : Number(sqlDateArr3[0]);
    const sMinute = Number(sqlDateArr3[1]);
    const sqlDateArr4 = sqlDateArr3[2].split(".");
    // format of sqlDateArr4[] = ['ss','ms']
    const sSecond = isNaN(Number(sqlDateArr4[0])) ? 0 : Number(sqlDateArr4[0]);
    const sMillisecond = isNaN(Number(sqlDateArr4[1])) ? 0 : Number(sqlDateArr4[1]);

    console.log(new Date(sYear, sMonth, sDay, sHour, sMinute, sSecond, sMillisecond));

    return new Date(sYear, sMonth, sDay, sHour, sMinute, sSecond, sMillisecond);
  }

  public static getDateByLocale(date: Date, locale: string): string {
    if (date != null) {
      const options = { year: "numeric", month: "long", day: "numeric" };
      try {
        const parsedDate = DateHelper.sqlToJsDate(date);
        console.log(parsedDate.toLocaleDateString(locale, options));
        return parsedDate.toLocaleDateString(locale, options);
      } catch (e) {
        console.log(e);
      }
    } else {
      return "";
    }
  }
}
