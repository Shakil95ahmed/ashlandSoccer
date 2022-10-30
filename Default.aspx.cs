using System;
using System.Web;
using System.Web.UI.WebControls;



public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        string sqlStatement;
        //sqlStatement = "SELECT * from schedule";
        //sqlStatement = "SELECT Week, Time_Slot, Field, Home, Visitor, Status from SCHEDULE ORDER BY SCHEDULE.WEEK";

        //sqlStatement = "SELECT DATES.PLAY_DATE, Time_Slot, Field, Home, Visitor, Status from SCHEDULE, DATES WHERE DATES.WEEK = SCHEDULE.WEEK ORDER BY SCHEDULE.WEEK";
        //sqlStatement = "SELECT DATES.PLAY_DATE, GAMETIME.GAME_TIME, FIELDS.FIELD_NAME,TEAMNAME.TEAM_NAME, TEAMS_1.TEAM_NAME, STATUS.FULL_STATUS from SCHEDULE, DATES, GAMETIME, FIELDS,STATUS, TEAMNAME, TEAMNAME AS TEAMS_1 WHERE DATES.WEEK = SCHEDULE.WEEK AND GAMETIME.TIME_SLOT =SCHEDULE.TIME_SLOT AND FIELDS.FIELD = SCHEDULE.FIELD AND STATUS.STATUS = SCHEDULE.STATUS AND TEAMNAME.TEAM_NO = SCHEDULE.HOME AND TEAMS_1.TEAM_NO = SCHEDULE.VISITOR ORDER BY SCHEDULE.WEEK";
        if (!IsPostBack)
        {
            myDatabaseConnection.fillDropDownList(ddTeam, lbTeam, "TEAMNAME", "TEAM_NAME", "TEAM_NO", ref
           lblErrorMessage);
            myDatabaseConnection.fillDropDownList(ddField, lbField, "FIELDS", "FIELD_NAME", "FIELD", ref
           lblErrorMessage);
            myDatabaseConnection.fillDropDownList(ddStatus, lbStatus, "STATUS", "FULL_STATUS", "STATUS", ref
           lblErrorMessage);
        }


        sqlStatement = "SELECT DATES.PLAY_DATE, GAMETIME.GAME_TIME, FIELDS.FIELD_NAME,";
        sqlStatement += " TEAMNAME.TEAM_NAME, TEAMS_1.TEAM_NAME, STATUS.FULL_STATUS";
        sqlStatement += " from SCHEDULE, DATES, GAMETIME, FIELDS, STATUS, TEAMNAME, TEAMNAME AS TEAMS_1";
        sqlStatement += " WHERE DATES.WEEK = SCHEDULE.WEEK";
        sqlStatement += " AND GAMETIME.TIME_SLOT = SCHEDULE.TIME_SLOT";
        sqlStatement += " AND FIELDS.FIELD = SCHEDULE.FIELD";
        sqlStatement += " AND STATUS.STATUS = SCHEDULE.STATUS";
        sqlStatement += " AND TEAMNAME.TEAM_NO = SCHEDULE.HOME";
        sqlStatement += " AND TEAMS_1.TEAM_NO = SCHEDULE.VISITOR";
        //if ddStatus selected
        if (ddStatus.SelectedIndex > 0)
        {
            sqlStatement += " AND SCHEDULE.STATUS = '" + lbStatus.Items[ddStatus.SelectedIndex - 1] + "'";
        }
        //if ddField selected
        if (ddField.SelectedIndex > 0)
        {
            sqlStatement += " AND SCHEDULE.FIELD = " + lbField.Items[ddField.SelectedIndex - 1];
        }
        //if ddTeam selected
        if (ddTeam.SelectedIndex > 0)
        {
            sqlStatement += " AND (SCHEDULE.HOME = " + lbTeam.Items[ddTeam.SelectedIndex - 1] + "OR SCHEDULE.VISITOR = " + lbTeam.Items[ddTeam.SelectedIndex - 1] + ")";
        }

        sqlStatement += " ORDER BY SCHEDULE.WEEK";
        myDatabaseConnection.executeSQL(sqlStatement, ref gvDisplay, ref lblErrorMessage);

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        string sqlStatement;
        

        if (!IsPostBack)
        {
            myDatabaseConnection.fillDropDownList(ddTeam, lbTeam, "TEAMNAME", "TEAM_NAME", "TEAM_NO", ref
            lblErrorMessage);
            myDatabaseConnection.fillDropDownList(ddField, lbField, "FIELDS", "FIELD_NAME", "FIELD", ref
            lblErrorMessage);
            myDatabaseConnection.fillDropDownList(ddStatus, lbStatus, "STATUS", "FULL_STATUS", "STATUS",
            ref lblErrorMessage);
        }

        sqlStatement = "SELECT DATES.PLAY_DATE, GAMETIME.GAME_TIME, FIELDS.FIELD_NAME,";
        sqlStatement += " TEAMNAME.TEAM_NAME, TEAMS_1.TEAM_NAME, STATUS.FULL_STATUS";
        sqlStatement += " from SCHEDULE, DATES, GAMETIME, FIELDS, STATUS, TEAMNAME, TEAMNAME AS TEAMS_1";
        sqlStatement += " WHERE DATES.WEEK = SCHEDULE.WEEK";
        sqlStatement += " AND GAMETIME.TIME_SLOT = SCHEDULE.TIME_SLOT";
        sqlStatement += " AND FIELDS.FIELD = SCHEDULE.FIELD";
        sqlStatement += " AND STATUS.STATUS = SCHEDULE.STATUS";
        sqlStatement += " AND TEAMNAME.TEAM_NO = SCHEDULE.HOME";
        sqlStatement += " AND TEAMS_1.TEAM_NO = SCHEDULE.VISITOR";

        //if ddStatus selected
        if (ddStatus.SelectedIndex > 0)
        {
            sqlStatement += " AND SCHEDULE.STATUS = '" + lbStatus.Items[ddStatus.SelectedIndex - 1] + "'";
        }
        //if ddField selected
        if (ddField.SelectedIndex > 0)
        {
            sqlStatement += " AND SCHEDULE.FIELD = " + lbField.Items[ddField.SelectedIndex - 1];
        }
        //if ddTeam selected
        if (ddTeam.SelectedIndex > 0)
        {
            sqlStatement += " AND (SCHEDULE.HOME = " + lbTeam.Items[ddTeam.SelectedIndex - 1] + "OR SCHEDULE.VISITOR = " + lbTeam.Items[ddTeam.SelectedIndex - 1] + ")";
        }
        
        sqlStatement += " ORDER BY SCHEDULE.WEEK";
        myDatabaseConnection.executeSQL(sqlStatement, ref gvDisplay, ref lblErrorMessage);
    }
}