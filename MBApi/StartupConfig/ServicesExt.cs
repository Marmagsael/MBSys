using MBApiLibrary.DataAccess._00_CT;
using MBApiLibrary.DataAccess._00_CT.Interfaces;
using MBApiLibrary.DataAccess._00_Login;
using MBApiLibrary.DataAccess._00_Login.Interface;
using MBApiLibrary.DataAccess._00_Main;
using MBApiLibrary.DataAccess._00_Main.Interface;
using MBApiLibrary.DataAccess._10_Pis;
using MBApiLibrary.DataAccess._10_Pis.Attendance;
using MBApiLibrary.DataAccess._10_Pis.Interface;
using MBApiLibrary.DataAccess._10_Pis.OPis;
using MBApiLibrary.DataAccess._20_Pay;
using MBApiLibrary.DataAccess._20_Pay.DA0605;
using MBApiLibrary.DataAccess._20_Pay.Interface;
using MBApiLibrary.DataAccess._20_Pay.OPay;
using MBApiLibrary.DataAccess._20_Pay.Report;
using MBApiLibrary.DataAccess._90_Utils;
using MBApiLibrary.DataAccess._90_Utils.Interface;

namespace MBApi.StartupConfig;

public static class ServicesExt
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void AddApiInjectionServices(this WebApplicationBuilder builder)
    {
        // -- Utils ------------------------------------------------------------
        builder.Services.AddScoped<I_90_001_MySqlDataAccess,    _90_001_MySqlDataAccess>();
        builder.Services.AddScoped<I_09_02_VarsGlobal,          _09_02_VarsGlobal>();
        builder.Services.AddScoped<IMainmenuDataAccess,         MainmenuDataAccess>();
        builder.Services.AddScoped<IMsdsDataAccess,             MsdsDataAccess>();
        builder.Services.AddScoped<ISessionDataAccess,          SessionDataAccess>();

        // -- Login ------------------------------------------------------------
        builder.Services.AddScoped<I_00_001_LoginAccess,        _00_001_LoginAccess>();

        // -- CT ---------------------------------------------------------------
        builder.Services.AddScoped<I_00_CTDataAccess,           _00_CTDataAccess>();

        // -- Main -------------------------------------------------------------
        builder.Services.AddScoped<I_00MainDA,                  _00MainDA>();
        builder.Services.AddScoped<I_00MainDataMakerAccess,     _00MainDataMakerAccess>();
        builder.Services.AddScoped<I_00MainPisAccess,           _00MainPisAccess>();
        builder.Services.AddScoped<I_00MainPisTblMakerAccess,   _00MainPisTblMakerAccess>();
        builder.Services.AddScoped<I_00MainTblMakerAccess,      _00MainTblMakerAccess>();
        builder.Services.AddScoped<I_00UsersAccess,             _00UsersAccess>();
        builder.Services.AddScoped<I_00UserscompanyDataAccess,  _00UserscompanyDataAccess>();
        builder.Services.AddScoped<I_00CityDataAccess,          _00CityDataAccess>();
        builder.Services.AddScoped<I_00ClientDataAccess,        _00ClientDataAccess>();
        builder.Services.AddScoped<I_00CompanyusersDataAccess,  _00CompanyusersDataAccess>();
        builder.Services.AddScoped<I_00CompanyusertypeDataAccess, _00CompanyusertypeDataAccess>();
        builder.Services.AddScoped<I_00CountryDataAccess,       _00CountryDataAccess>();
        builder.Services.AddScoped<I_00ProvincestateDataAccess, _00ProvincestateDataAccess>();
        builder.Services.AddScoped<I_00UsercompanyaddDataAccess,_00UsercompanyaddDataAccess>();
        builder.Services.AddScoped<I_00_CurrencyDataAccess,     _00_CurrencyDataAccess>();
        builder.Services.AddScoped<I_AcctgTableMaker,           _AcctgTableMaker>();
        builder.Services.AddScoped<IPissettingsDataAccess,      PissettingsDataAccess>();
        builder.Services.AddScoped<ISystemuserDataAccess,       SystemuserDataAccess>();
        builder.Services.AddScoped<IDevdataDataAccess, MBApiLibrary.DataAccess._00_Main.RdevdataDataAccess>();
        builder.Services.AddScoped<IPenaltyDataAccess, MBApiLibrary.DataAccess._00_Main.RpenaltyDataAccess>();

        // -- PIS --------------------------------------------------------------
        builder.Services.AddScoped<I_10_EmpmasDataAccess,               _10_EmpmasDataAccess>();
        builder.Services.AddScoped<IPisEmpmasDataAccess,                PisEmpmasDataAccess>();
        builder.Services.AddScoped<IEmpmasInternalDataAccess,           EmpmasInternalDataAccess>();
        builder.Services.AddScoped<IAttdailyDataAccess,                 AttdailyDataAccess>();
        builder.Services.AddScoped<IAttdutytypeDataAccess,              AttdutytypeDataAccess>();
        builder.Services.AddScoped<IAttpunches1DataAccess,              Attpunches1DataAccess>();
        builder.Services.AddScoped<IAttpunchesDataAccess,               AttpunchesDataAccess>();
        builder.Services.AddScoped<IAttreqdtlDataAccess,                AttreqdtlDataAccess>();
        builder.Services.AddScoped<IAttreqhdrDataAccess,                AttreqhdrDataAccess>();
        builder.Services.AddScoped<IAttreqhistDataAccess,               AttreqhistDataAccess>();
        builder.Services.AddScoped<IAttreqtypeDataAccess,               AttreqtypeDataAccess>();
        builder.Services.AddScoped<IAtttemplateDataAccess,              AtttemplateDataAccess>();
        builder.Services.AddScoped<IAtttemplatereqdtlDataAccess,        AtttemplatereqdtlDataAccess>();
        builder.Services.AddScoped<IAtttemplatereqhdrDataAccess,        AtttemplatereqhdrDataAccess>();
        builder.Services.AddScoped<IAtttemplatereqhistDataAccess,       AtttemplatereqhistDataAccess>();
        builder.Services.AddScoped<IAttendanceDataAccess,               AttendanceDataAccess>();
        builder.Services.AddScoped<IDeploymodeDataAccess,               DeploymodeDataAccess>();
        builder.Services.AddScoped<IDeprecDataAccess,                   DeprecDataAccess>();
        builder.Services.AddScoped<IDesignationDataAccess,              DesignationDataAccess>();
        builder.Services.AddScoped<IDeviationDataAccess,                DeviationDataAccess>();
        builder.Services.AddScoped<IEmpblockpostDataAccess,             EmpblockpostDataAccess>();
        builder.Services.AddScoped<IEmploymenttypeDataAccess,           EmploymenttypeDataAccess>();
        builder.Services.AddScoped<IEmploytypeDataAccess,               EmploytypeDataAccess>();
        builder.Services.AddScoped<IEmpmasgrpDataAccess,                EmpmasgrpDataAccess>();
        builder.Services.AddScoped<IEmpmovementDataAccess,              EmpmovementDataAccess>();
        builder.Services.AddScoped<IEmptranmovementDataAccess,          EmptranmovementDataAccess>();
        builder.Services.AddScoped<IInvDataAccess,                      InvDataAccess>();
        builder.Services.AddScoped<IInvdtlDataAccess,                   InvdtlDataAccess>();
        builder.Services.AddScoped<IInv_brandDataAccess,                Inv_brandDataAccess>();
        builder.Services.AddScoped<IInv_categoryDataAccess,             Inv_categoryDataAccess>();
        builder.Services.AddScoped<IInv_makeDataAccess,                 Inv_makeDataAccess>();
        builder.Services.AddScoped<IInv_statusDataAccess,               Inv_statusDataAccess>();
        builder.Services.AddScoped<IInv_typeDataAccess,                 Inv_typeDataAccess>();
        builder.Services.AddScoped<ILeaveapplicationDataAccess,         LeaveapplicationDataAccess>();
        builder.Services.AddScoped<ILeaveapplicationdtlDataAccess,      LeaveapplicationdtlDataAccess>();
        builder.Services.AddScoped<ILeaveapproverDataAccess,            LeaveapproverDataAccess>();
        builder.Services.AddScoped<ILeavecreditDataAccess,              LeavecreditDataAccess>();
        builder.Services.AddScoped<ILeavedaytypeDataAccess,             LeavedaytypeDataAccess>();
        builder.Services.AddScoped<ILeavedefaultapproverDataAccess,     LeavedefaultapproverDataAccess>();
        builder.Services.AddScoped<ILeavegrpapproverDataAccess,         LeavegrpapproverDataAccess>();
        builder.Services.AddScoped<ILeavegrpDataAccess,                 LeavegrpDataAccess>();
        builder.Services.AddScoped<ILeavetypeDataAccess,                LeavetypeDataAccess>();
        builder.Services.AddScoped<ILvcreditDataAccess,                 LvcreditDataAccess>();
        builder.Services.AddScoped<IMymovementDataAccess,               MymovementDataAccess>();
        builder.Services.AddScoped<IOtdaytypeDataAccess,                OtdaytypeDataAccess>();
        builder.Services.AddScoped<IOtdutytypeDataAccess,               OtdutytypeDataAccess>();
        builder.Services.AddScoped<IOtreqdtlDataAccess,                 OtreqdtlDataAccess>();
        builder.Services.AddScoped<IOtreqhdrDataAccess,                 OtreqhdrDataAccess>();
        builder.Services.AddScoped<IOtreqhistDataAccess,                OtreqhistDataAccess>();
        builder.Services.AddScoped<IParaDataAccess,                     ParaDataAccess>();
        builder.Services.AddScoped<IPositionDataAccess,                 PositionDataAccess>();
        builder.Services.AddScoped<IRcivstatDataAccess, MBApiLibrary.DataAccess._10_Pis.RcivstatDataAccess>();
        builder.Services.AddScoped<IRdepapproverDataAccess, MBApiLibrary.DataAccess._10_Pis.RdepapproverDataAccess>();
        builder.Services.AddScoped<IRdepartmentDataAccess, MBApiLibrary.DataAccess._10_Pis.RdepartmentDataAccess>();
        builder.Services.AddScoped<IRdepDataAccess, MBApiLibrary.DataAccess._10_Pis.RdepDataAccess>();
        builder.Services.AddScoped<IRdeploymentDataAccess, MBApiLibrary.DataAccess._10_Pis.RdeploymentDataAccess>();
        builder.Services.AddScoped<IRdivisionDataAccess, MBApiLibrary.DataAccess._10_Pis.RdivisionDataAccess>();
        builder.Services.AddScoped<IRempstatDataAccess, MBApiLibrary.DataAccess._10_Pis.RempstatDataAccess>();
        builder.Services.AddScoped<IRempstat_baseDataAccess, MBApiLibrary.DataAccess._10_Pis.Rempstat_baseDataAccess>();
        builder.Services.AddScoped<IRsectionDataAccess, MBApiLibrary.DataAccess._10_Pis.RsectionDataAccess>();
        builder.Services.AddScoped<ITrandeploymentapprovalDataAccess,           TrandeploymentapprovalDataAccess>();
        builder.Services.AddScoped<ITrandeploymentapprovalhistoryDataAccess,    TrandeploymentapprovalhistoryDataAccess>();
        builder.Services.AddScoped<ITrandeploymentDataAccess,                   TrandeploymentDataAccess>();
        builder.Services.AddScoped<ITrandeviationapprovalDataAccess,            TrandeviationapprovalDataAccess>();
        builder.Services.AddScoped<ITrandeviationapprovalhistoryDataAccess,     TrandeviationapprovalhistoryDataAccess>();
        builder.Services.AddScoped<ITrandeviationDataAccess,                    TrandeviationDataAccess>();
        builder.Services.AddScoped<ITrandeviationotherDataAccess,               TrandeviationotherDataAccess>();
        builder.Services.AddScoped<ITrandisciplinaryapprovalDataAccess,         TrandisciplinaryapprovalDataAccess>();
        builder.Services.AddScoped<ITrandisciplinaryapprovalhistoryDataAccess,  TrandisciplinaryapprovalhistoryDataAccess>();
        builder.Services.AddScoped<ITrandisciplinaryDataAccess,                 TrandisciplinaryDataAccess>();
        builder.Services.AddScoped<ITranexonerateapprovalDataAccess,            TranexonerateapprovalDataAccess>();
        builder.Services.AddScoped<ITranexonerateapprovalhistoryDataAccess,     TranexonerateapprovalhistoryDataAccess>();
        builder.Services.AddScoped<ITranexonerateDataAccess,                    TranexonerateDataAccess>();
        builder.Services.AddScoped<ITraninvestigateapprovalDataAccess,          TraninvestigateapprovalDataAccess>();
        builder.Services.AddScoped<ITraninvestigateapprovalhistoryDataAccess,   TraninvestigateapprovalhistoryDataAccess>();
        builder.Services.AddScoped<ITraninvestigateDataAccess,                  TraninvestigateDataAccess>();
        builder.Services.AddScoped<ITranreinstatementapprovalDataAccess,        TranreinstatementapprovalDataAccess>();
        builder.Services.AddScoped<ITranreinstatementapprovalhistoryDataAccess, TranreinstatementapprovalhistoryDataAccess>();
        builder.Services.AddScoped<ITranreinstatementDataAccess,                TranreinstatementDataAccess>();

        // -- OPis -------------------------------------------------------------
        builder.Services.AddScoped<IOChildrenDataAccess,        OChildrenDataAccess>();
        builder.Services.AddScoped<IOCivstatDataAccess,         OCivstatDataAccess>();
        builder.Services.AddScoped<IOClientDataAccess,          OClientDataAccess>();
        builder.Services.AddScoped<IOCoinfoDataAccess,          OCoinfoDataAccess>();
        builder.Services.AddScoped<IODeprecDataAccess,          ODeprecDataAccess>();
        builder.Services.AddScoped<IOEducateDataAccess,         OEducateDataAccess>();
        builder.Services.AddScoped<IOEmergencDataAccess,        OEmergencDataAccess>();
        builder.Services.AddScoped<IOEmployDataAccess,          OEmployDataAccess>();
        builder.Services.AddScoped<IOEmpmasDataAccess,          OEmpmasDataAccess>();
        builder.Services.AddScoped<IOEmpstatDataAccess,         OEmpstatDataAccess>();
        builder.Services.AddScoped<IOFamilyDataAccess,          OFamilyDataAccess>();
        builder.Services.AddScoped<IOGenderDataAccess,          OGenderDataAccess>();
        builder.Services.AddScoped<IOInsuranceaccidentDataAccess, OInsuranceaccidentDataAccess>();
        builder.Services.AddScoped<IOMlacodeDataAccess,         OMlacodeDataAccess>();
        builder.Services.AddScoped<IOParentDataAccess,          OParentDataAccess>();
        builder.Services.AddScoped<IOPisReportDataAccess,       OPisReportDataAccess>();
        builder.Services.AddScoped<IOPositionDataAccess,        OPositionDataAccess>();
        builder.Services.AddScoped<IOProcodeDataAccess,         OProcodeDataAccess>();
        builder.Services.AddScoped<IOReferDataAccess,           OReferDataAccess>();
        builder.Services.AddScoped<IOTrainDataAccess,           OTrainDataAccess>();

        // -- Payroll -----------------------------------------------------------
        builder.Services.AddScoped<I_20_001_PayDataAccess,      _20_001_PayDataAccess>();
        builder.Services.AddScoped<I_20_002_PayTblMaker,        _20_002_PayTblMaker>();
        builder.Services.AddScoped<ICoaDataAccess,              CoaDataAccess>();
        builder.Services.AddScoped<IDedmandatoryDataAccess,     DedmandatoryDataAccess>();
        builder.Services.AddScoped<IDutyrenderedDataAccess,     DutyrenderedDataAccess>();
        builder.Services.AddScoped<IEmpratesDataAccess,         EmpratesDataAccess>();
        builder.Services.AddScoped<IEmpratesdtlDataAccess,      EmpratesdtlDataAccess>();
        builder.Services.AddScoped<IEmprateshistDataAccess,     EmprateshistDataAccess>();
        builder.Services.AddScoped<IFixedearningsDataAccess,    FixedearningsDataAccess>();
        builder.Services.AddScoped<IFixedearnings_grpDataAccess,        Fixedearnings_grpDataAccess>();
        builder.Services.AddScoped<IFixedearnings_grp_empDataAccess,    Fixedearnings_grp_empDataAccess>();
        builder.Services.AddScoped<ILoanhdrDataAccess,          LoanhdrDataAccess>();
        builder.Services.AddScoped<ILoansDataAccess,            LoansDataAccess>();
        builder.Services.AddScoped<IMatrixpagibigDataAccess,    MatrixpagibigDataAccess>();
        builder.Services.AddScoped<IMatrixphicDataAccess,       MatrixphicDataAccess>();
        builder.Services.AddScoped<IMatrixsssDataAccess,        MatrixsssDataAccess>();
        builder.Services.AddScoped<IMatrixwtaxDataAccess,       MatrixwtaxDataAccess>();
        builder.Services.AddScoped<IPaymaindtlDataAccess,       PaymaindtlDataAccess>();
        builder.Services.AddScoped<IPaymainhdrDataAccess,       PaymainhdrDataAccess>();
        builder.Services.AddScoped<IPaymainhistoryDataAccess,   PaymainhistoryDataAccess>();
        builder.Services.AddScoped<IPaymainvisacctDataAccess1,  PaymainvisacctDataAccess>();
        builder.Services.AddScoped<IPayrateDataAccess,          PayrateDataAccess>();
        builder.Services.AddScoped<IPayrollgrpDataAccess,       PayrollgrpDataAccess>();
        builder.Services.AddScoped<IPayrollgrpratesDataAccess,  PayrollgrpratesDataAccess>();
        builder.Services.AddScoped<IPayrollprdDataAccess,       PayrollprdDataAccess>();
        builder.Services.AddScoped<IPaytranDataAccess,          PaytranDataAccess>();
        builder.Services.AddScoped<ISettingsDataAccess,         SettingsDataAccess>();
        builder.Services.AddScoped<ITbltranDataAccess,          TbltranDataAccess>();
        builder.Services.AddScoped<IUserpayinprocessDataAccess, UserpayinprocessDataAccess>();
        builder.Services.AddScoped<IDa605DataAccess,            Da605DataAccess>();
        builder.Services.AddScoped<IReportDataAccess,           ReportDataAccess>();

        // -- OPay -------------------------------------------------------------
        builder.Services.AddScoped<IOChartofacctDataAccess,     OChartofacctDataAccess>();
        builder.Services.AddScoped<IOEmpportalDataAccess,       OEmpportalDataAccess>();
        builder.Services.AddScoped<IOLoansDataAccess,           OLoansDataAccess>();
        builder.Services.AddScoped<IOPaymainhdrDataAccess,      OPaymainhdrDataAccess>();
        builder.Services.AddScoped<IOPayrollgrpDataAccess,      OPayrollgrpDataAccess>();
        builder.Services.AddScoped<IOtbltranDataAccess,         OtbltranDataAccess>();
        builder.Services.AddScoped<IOTbltrandtlDataAccess,      OTbltrandtlDataAccess>();
    }
}

