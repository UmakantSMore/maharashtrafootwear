<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="addeditcollectiontrip.aspx.cs" Inherits="addeditcollectiontrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="Template/dist/css/AdminLTE.min.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                <!-- left column -->
                <div class="col-md-12">
                    <!-- general form elements -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3><span style="color: red">* Indicates Required Fields</span></h3>
                            <h3 class="box-title" style="text-align: center"><b id="spnMessgae" runat="server"></b></h3>
                            <%--<cc1:ToolkitScriptManager ID="toolScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <div class="box-body">

                            <div class="form-group row">

                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Employee</label>
                                    <asp:ListBox ID="lstemployee" runat="server" class="form-control select2"></asp:ListBox>
                                    <asp:HiddenField ID="hfempid" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="lstemployee" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>


                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Day</label>
                                    <asp:ListBox ID="lstday" runat="server" class="form-control select2">
                                        <asp:ListItem Text="Sunday" Value="Sunday" />
                                        <asp:ListItem Text="Monday" Value="Monday" />
                                        <asp:ListItem Text="Tuesday" Value="Tuesday" />
                                        <asp:ListItem Text="Wednesday" Value="Wednesday" />
                                        <asp:ListItem Text="Thursday" Value="Thursday"/>
                                        <asp:ListItem Text="Friday" Value="Friday" />
                                        <asp:ListItem Text="Saturday" Value="Saturday" />
                                    </asp:ListBox>
                                    <asp:HiddenField ID="hfday" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="lstday" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="form-group row">

                                <div class="col-xs-4">
                                    <label for="exampleInputEmail1">City Names<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtcityname" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVtxtBankBranch" runat="server" Display="Dynamic" ControlToValidate="txtcityname" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>

                                </div>
                                
                            </div>
                            
                            <br />
                            

                            <div class="col-md-12">
                                <div class="box-footer" style="text-align: center">

                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="c1" Text="SAVE" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn btn-default" OnClick="btnCancel_Click" Text="CANCEL" />
                                </div>
                            </div>





                            </>
                 <%--</div>--%>
                   
                </>
                <!-- /.box-body -->



                            </>
            <!-- /.box -->

                            <!-- Form Element sizes -->

                            <!-- /.box -->


                            <!-- /.box -->

                            <!-- Input addon -->

                            <!-- /.box -->

                        </div>
                        <!--/.col (left) -->
                        <!-- right column -->

                        <!--/.col (right) -->
                    </div>
                </div>
            </div>
        </ContentTemplate>


    </asp:UpdatePanel>

    <!-- jQuery 3 -->
    <script src="Template/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="Template/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- DataTables -->
    <script src="Template/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="Template/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <!-- SlimScroll -->
    <script src="Template/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="Template/bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="Template/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="Template/dist/js/demo.js"></script>
    <!-- page script -->

    <script type="text/javascript">
        function pageLoad() {
            // JS to execute during full and partial postbacks
            initDropDowns();


        }

        $(document).ready(function () {

            initDropDowns();

        });

        function initDropDowns() {

            $("#<%=lstemployee.ClientID%>").select2({

                allowClear: true

            }).on('change.select2', function () {
         //alert("Selected value is: "+$("#<%=lstemployee.ClientID%>").select2("val"));
                    $('[id*=hfempid]').val($(this).val());
                });


            $("#<%=lstday.ClientID%>").select2({

                allowClear: true

            }).on('change.select2', function () {
         //alert("Selected value is: "+$("#<%=lstday.ClientID%>").select2("val"));
                    $('[id*=hfday]').val($(this).val());
                });
        }

    </script>

    <script type="text/javascript">
        

    </script>


    <script type="text/javascript">
        

    </script>




</asp:Content>


