<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Storylia | Cartoon Me  </title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .bd-example-modal-lg .modal-dialog {
            display: table;
            position: relative;
            margin: 0 auto;
            top: calc(50% - 24px);
        }

            .bd-example-modal-lg .modal-dialog .modal-content {
                background-color: transparent;
                border: none;
            }

        .topBack1 {
            margin-left: auto;
            margin-right: auto;
            width: 200px;
            display: block;
        }

        .back1 {
            margin-left: auto;
            margin-right: auto;
            width: 500px;
            display: block;
        }
    </style>
    <link rel="icon" href="/favico.ico" />
    <script src="Scripts/jquery-3.x-git.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function modal() {
            $('.modal').modal('show');
            setTimeout(function () {
                console.log('hejsan');
                $('.modal').modal('hide');
            }, 120000);
        }
    </script>
</head>
<body>
    <header class="p-3 bg-dark text-white">
        <div class="container">
            <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" class="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">
                    <svg class="bi me-2" width="40" height="32" role="img" aria-label="Bootstrap">
                        <use xlink:href="#bootstrap"></use></svg>
                </a>

                <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                    <li><a href="https://storylia.com" target="_blank" class="nav-link px-2 text-white">Storylia.com</a></li>
                </ul>

                <form class="col-12 col-lg-auto mb-3 mb-lg-0 me-lg-3">
                    <input type="search" class="form-control form-control-dark" placeholder="Search..." aria-label="Search">
                </form>

                <div class="text-end">
                    <button type="button" class="btn btn-warning">Sign-up</button>
                </div>
            </div>
        </div>
    </header>

    <form id="form1" runat="server">


        <div class="container my-5">
            <div class="row p-4 pb-0 pe-lg-0 pt-lg-5 align-items-center rounded-3 border shadow-lg">
                <div class="px-2 pt-2 my-2 text-center border-bottom">
                    <h1 class="display-4 fw-bold lh-1">Welcome To Storylia Cartoonizer</h1>
                    <p class="lead">This page removes the background from your image, cartoonizes it, and places on the neck of the sample image.</p>
                    <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
                        <button type="button" class="btn btn-primary btn-lg px-4 me-md-2 fw-bold" onclick="document.getElementById('started').scrollIntoView();">Get Started</button>

                    </div>
                    <br />
                </div>
                <div class="px-2 pt-2 my-2 text-center border-bottom">
                    <img class="rounded-lg-3" src="sample1.jpg" alt="" width="720">
                </div>
            </div>
        </div>


        <div class="modal fade bd-example-modal-lg" data-backdrop="static" data-keyboard="false" tabindex="-1">
            <div class="modal-dialog modal-sm">
                <div class="modal-content" style="width: 48px">
                    <span class="fa fa-spinner fa-spin fa-3x"></span>
                    <div class="spinner-border  text-primary" style="width: 4rem; height: 4rem;" role="status">
                        <br />

                    </div>
                </div>
            </div>
        </div>

        <div class="container  my-5" id="started">
            <div class="row p-4 pb-0 pe-lg-0 pt-lg-5 align-items-center rounded-3 border shadow-lg">
                <div class="px-2 pt-2 my-2 text-center border-bottom">
                    <h1 class="display-4 fw-bold">Upload Your Image To Know How It Works...!</h1>
                    <p class="lead">This page removes the background from your image, cartoonizes it, and places on the neck of the sample image.</p>
                    <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
                        <div class="col-auto">
                            <asp:FileUpload CssClass="form-control form-control-lg" ID="FileUpload1" runat="server" />
                        </div>
                        <div class="col-auto">
                            <asp:Button OnClientClick="modal();" ID="ButtonUploadImage" CssClass="btn btn-outline-secondary btn-lg px-4" runat="server" Text="Upload and Cartoonize" OnClick="ButtonUploadImage_Click" />
                        </div>
                        <div class="col-auto">
                            <asp:Label ID="LabelResult" CssClass="lead" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                </div>
                <div>
                    <asp:Image ID="ImageSource" Width="200px" runat="server" />
                    <asp:Image ID="ImageResultCartoon" Width="200px" runat="server" />
                    <asp:Image ID="ImageResultBackRemoved" Width="200px" runat="server" />
                    <br />
                    <div class="slidecontainer px-2 pt-2 my-2 text-center ">
                        <p class="lead">Change Head Size To Fetch </p>
                        <input type="range" min="1" max="80" value="50" class="slider" id="Slider">
                    </div>

                    <div style="">
                        <asp:Image ID="ImageOnCover1" CssClass="topBack1" ImageUrl="3.jpg" Width="70px" runat="server" />
                    </div>
                    <div style="">

                        <asp:Image ID="Image1" CssClass="back1" ImageUrl="back3.jpg" Width="500px" runat="server" />
                    </div>

                </div>
                    <asp:Button ID="ButtonClear" CssClass="btn  me-2" runat="server" Text="Clear Last Pics" OnClick="ButtonClear_Click" />

            </div>
        </div>
    </form>

    <script type="text/javascript">

        const slider = document.getElementById('Slider');
        slider.addEventListener('input', handleChange);


        function handleChange(e) {
            const img = document.getElementById("<%=ImageOnCover1.ClientID%>");
            const { value, max } = e.target;
            img.style.width = `${value * 2}px`;
        }
    </script>


</body>
</html>
