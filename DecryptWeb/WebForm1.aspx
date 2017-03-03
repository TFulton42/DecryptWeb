<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DecryptWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 100px;
            text-align: left;
        }
        .auto-style4 {
            width: 27px;
        }
        .auto-style5 {
            top: 0px;
            left: 0px;
        }
    </style>
</head>
<body style="background-color: #00ffff;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h2>Decryption Tools</h2>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4" style="vertical-align:top;">
                    <asp:Label ID="Label1" runat="server" Text="Original Text"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Height="250px" TextMode="MultiLine" CssClass="auto-style5" Width="900px" Font-Size="12pt"></asp:TextBox><br />
                    <asp:Label ID="Label3" runat="server" Text="Decryption/Encryption Key"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" Height="25px" Style="margin-top: 1px" Width="900px" TextMode="MultiLine" Font-Size="12pt"></asp:TextBox><br />
                    <asp:Label ID="Label6" runat="server" Text="Expected Text/Cipher Alphabet"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox6" runat="server" Height="25px" Style="margin-top: 1px" Width="900px" TextMode="MultiLine" Font-Size="12pt"></asp:TextBox><br />
                    <asp:Label ID="Label2" runat="server" Text="Output Text"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Height="250px" Style="margin-top: 1px" Width="900px" TextMode="MultiLine" Font-Size="12pt"></asp:TextBox><br />
                </td>
                <td class="auto-style3" style="vertical-align:top;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; margin-top: 40px; width: 200px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList><br/>
    
                            <asp:DropDownList ID="DropDownList2" runat="server" style="z-index: 1; margin-top: 10px; width: 200px">
                            </asp:DropDownList><br/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
    
                    <asp:Button ID="Button1" runat="server" Text="Decrypt" OnClick="Button1_Click" style="z-index: 1; margin-top: 10px; width: 200px" /><br/>
    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" style="z-index: 1; margin-top: 20px; width: 200px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList><br/>
    
                            <asp:DropDownList ID="DropDownList4" runat="server" style="z-index: 1; margin-top: 10px; width: 200px">
                            </asp:DropDownList><br/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="Button2" runat="server" Text="Encrypt" style="z-index: 1; margin-top: 10px; width: 200px" OnClick="Button2_Click"/><br/>

                    <asp:Label ID="Label4" runat="server" Text="Offset:  "></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" Height="15px" Style="margin-top: 30px" Width="150px" TextMode="MultiLine" Font-Size="12pt"></asp:TextBox><br />
                    <asp:Label ID="Label5" runat="server" Text="Start Point:  "></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" Height="15px" Style="margin-top: 10px" Width="125px" TextMode="MultiLine" Font-Size="12pt"></asp:TextBox><br />

                    <asp:Button ID="Button3" runat="server" Text="Clear Original Text" style="z-index: 1; margin-top: 30px; width: 200px" OnClick="Button3_Click" /><br/>
                    <asp:Button ID="Button4" runat="server" Text="Save Original Text" style="z-index: 1; margin-top: 10px; width: 200px" OnClick="Button4_Click" /><br/>
                    <asp:Button ID="Button5" runat="server" Text="Restore Original Text" style="z-index: 1; margin-top: 10px; width: 200px" OnClick="Button5_Click" /><br/>
                    <asp:Button ID="Button6" runat="server" Text="Move Text" style="z-index: 1; margin-top: 10px; width: 200px" OnClick="Button6_Click" /><br/>
                    <asp:Button ID="Button7" runat="server" Text="Clear All" style="z-index: 1; margin-top: 10px; width: 200px" OnClick="Button7_Click" /><br/>
                </td>
            </tr>
        </table>
        <h2>Useful Links</h2>
        <a href="http://rumkin.com/tools/cipher/" target="_blank">Rumkin Cipher Tools</a><br/>
        <a href="http://practicalcryptography.com/ciphers/" target="_blank">Practical cryptography</a><br/>
        <a href="http://www.braingle.com/brainteasers/codes/" target="_blank">Braingle</a><br/>
        <a href="http://www.dcode.fr/enigma-machine-cipher" target="_blank">Enigma</a><br/>
        <a href="http://www.cryptogram.org/resources/cipher-types/" target="_blank">American Cryptogram Association Resources</a><br/>
        <a href="http://www.simonsingh.net/The_Black_Chamber/chamberguide.html" target="_blank">The Black Chamber</a><br/>
    
    </div>
    </form>
</body>
</html>
