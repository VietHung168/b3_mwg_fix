

var input = document;
input.onclick = function () {

    var d = document.getElementsByClassName("filter-show");
    for (let cs of d) {
        cs.style.display = "none";
    }

    var c = document.getElementsByClassName("filter-item");
    for (let cs of c) {
        cs.onclick = function () {
            showFilteritem(cs);
        }
    }

    
};


function showFilteritem(obj) {
    setTimeout(function () {
        var d = document.getElementsByClassName("filter-show");
        for (let cs of d) {
            cs.style.display = "none";
        }


        var c = obj.getElementsByClassName("filter-show");
        for (let cs of c) {
            cs.style.display = "block";
        }
    }, 100)
}

var bt = document.getElementsByClassName("c-btnbox");
for (let btcl of bt) {
    btcl.onclick = function () {
        if (btcl.classList.contains("act") == true) {
            btcl.classList.remove("act");
            //var typeFilter = btcl.querySelector("[data-typeFilter]");
            //var indexFilter = btcl.querySelector("[data-indexFilter]");
            //console.log(typeFilter);
            //console.log(indexFilter);
          //  const elements = document.querySelectorAll('[data-id="box1"]');
         //   const elements = document.querySelectorAll('[data-id="box1"]');
           // data - typeFilter="Hang" data - indexFilter=@i
            demchom--;
            document.getElementById("number").innerHTML = demchom;
            document.getElementById("number").style.display = "inline";
            if (demchom == 0) {
                document.getElementById("number").style.display = "none";
            }
        }
        else {
            btcl.classList.add("act");
            demchom++;
            document.getElementById("number").innerHTML = demchom;
            document.getElementById("number").style.display = "inline";

           

        }
       
      

    };
}

var demchom = 0;

var sortselect = document.getElementsByClassName("sort-select");
for (let ssl of sortselect) {
    ssl.onclick = function () {
        var initsort = ssl.getElementsByClassName("sort-select-main");
         initsort[0].style.display = "block";
    }


}

function noneselect() {
    setTimeout(function () {
        var sortselect1 = document.getElementsByClassName("sort-select");
        for (let ssl of sortselect1) {

            var initsort = ssl.getElementsByClassName("sort-select-main");
            initsort[0].style.display = "none";



        }
    },10)
}
var sortclick = document.getElementsByClassName("sort");
for (let sc of sortclick) {
    sc.onclick = function () {
        if (sc.classList.contains("active")) {
            sc.classList.remove("active");
        }
        else {
            for (let sc1 of sortclick) {
                sc1.classList.remove("active");
            }
            sc.classList.add("active");
            document.getElementsByClassName("sort-show")[0].innerHTML = document.getElementsByClassName("active")[0].innerHTML;

            noneselect();
            
         //   console.log(document.getElementsByClassName("sort-select-main")[0].style.display);


            

        }
        getproduct();
    }
}


function showsize(si) {
   var ss= document.getElementsByClassName('total-reloading');
    for (let s of ss) {
        s.innerHTML = si;
    }
}

$(document).ready(function () {
    $('.c-btnbox').click(function () {
        // data-typeFilter="Size" data-indexFilter=@i
       // console.log($(this).attr('data-typeFilter'));
      //  console.log($(this).attr('data-indexFilter'));
       
        getproduct();

       
    })
});

function getproduct() {
    var Hang = [];
    var gia = [];
    var loai = [];
    var cannag = [];
    var size = [];
    var sort = -1;
    var page = 1;
    var pagess = document.getElementsByClassName("page-item active")[0];
    page = $(pagess).attr('data-page');

    var sorts = document.getElementsByClassName("sort active")[0];
    sort = $(sorts).attr('data-id');

    var btn = document.getElementsByClassName("c-btnbox");
    for (let bt of btn) {
        if (bt.classList.contains("act")) {
            switch ($(bt).attr('data-typeFilter')) {
                case 'Hang':
                  
                    Hang.push($(bt).attr('data-indexFilter'));
                    break;
                case 'Loai':
                 
                    loai.push($(bt).attr('data-indexFilter'));
                    break;
                
                case 'Gia':
                    gia.push($(bt).attr('data-indexFilter'));
                    break;
                case 'CanNang':
                    cannag.push($(bt).attr('data-indexFilter'));
                    break;
                case 'Size':
                   // var tem = $(bt).attr('data-indexFilter');
                   // alert(" vo roi");
                   size.push($(bt).attr('data-indexFilter'));
                    break;

            }
           
          
        }

    }

    $.ajax({
        url: '/Home/getProducts',
        type: 'GET',
        traditional: true,
        data: {
            Hang : Hang,
            gia: gia,
            loai: loai,
            cannag: cannag,
            size: size,
            sort: sort,
            page: page

        },
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            var data = JSON.parse(response);
       //     $('.total-reloading').text = "" + data.length;
           // console.log(data.length);
            showsize(data.length );
                if(data.length == 0)
            $('#toy-grid').empty();
            if (data.length != 0) {
                $('#toy-grid').empty();
                for (var pr of data) {
                    var prhtm = `<div class="others-toy-item">
    <img src="${pr.img}" alt="" />
    <h3>
      
        ${pr.Name}
    </h3>
    <p class="others-toy-item-price">
       ${pr.Price * (100-pr.Promotion)/100} đ
    </p>
    <span class="others-toy-item-old-price">
        ${pr.Price} đ
    </span>
    <span class="others-toy-item-percent">
          ${pr.Promotion} %
    </span>

    <div class="others-toy-item-buy">
        <p class="txt">Chọn mua</p>
    </div>
</div>`;

                    $('#toy-grid').append(prhtm);

                }
            }
//           

           // $('#toy-grid').load('Home/listproduct',{
           //     aPList: data
           //});
        },
        error: function () {
        }
    })
}
function PageIndex(obj) {
    var page = document.getElementsByClassName("page-item");
    for (let pg of page) {
        pg.classList.remove("active");

    }
    obj.classList.add("active");
    console.log($(obj).attr('data-page'));
    getproduct();

    
}

function gotoPageIndex(index) {
    let tem = 0;
    var page = document.getElementsByClassName("page-item active")[0];
    tem = $(page).attr('data-page');

    if (index == 1) {
        tem;
    }
    if (index == -1) {
      //  console.log(tem.type())
        tem = tem - 1;
      //  alert(typeof(tem));
        tem = tem - 1;

       // alert(typeof(tem));
       
      
    }

  
    var pages = document.getElementsByClassName("page-item");
    for (let pg of pages) {
        pg.classList.remove("active");
    }
    for (let dem = 0; dem < 4; dem++) {
        console.log(dem +"/"+tem)
        if (dem == tem) {
            pages[dem].classList.add("active");
        }
    }

    getproduct();
  


}