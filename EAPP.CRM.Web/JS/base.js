function $(element) {
    return document.getElementById(element);
}
function $F(element) {
    return document.getElementById(element).value;
}

//日期选择

//obj 文本框引用
function selectData(obj){   
    var objPosition = getAbsolutePos(obj);   
    var container = $("mycal"); 
    container.style.left = objPosition.x+"px";   
    container.style.top = (objPosition.y+20)+"px";  
    container.style.position = "absolute";   
    container.style.display = "";   
    cal = new YAHOO.widget.Calendar("my","mycal",{ pages:2, close:true });   
    cal.render();   
    cal.selectEvent.subscribe(function(){   
        if (cal.getSelectedDates().length > 0) {   
            var selDate = cal.getSelectedDates()[0];   
            obj.value =  selDate.getFullYear() + "-" + (selDate.getMonth()+1) + "-" + selDate.getDate();   
        } else {   
            obj.value = "";   
        }   
        $("mycal").style.display = "none";   
    });
}

//获取控件位置
function getAbsolutePos(el)
{
    var SL = 0, ST = 0;
    var is_div = /^div$/i.test(el.tagName);
    if (is_div && el.scrollLeft)
        SL = el.scrollLeft;
    if (is_div && el.scrollTop)
        ST = el.scrollTop;
    var r = { x: el.offsetLeft - SL, y: el.offsetTop - ST };
    if (el.offsetParent)
    {
        var tmp = this.getAbsolutePos(el.offsetParent);
        r.x += tmp.x;
        r.y += tmp.y;
    }
    return r;
} 

function checkDll(oSrc, args)
{
    args.IsValid = (args.Value != "0");
}


function ckLoginName(oSrc, args)
{
     var res = EAPP.CRM.Web.AddUser.CheckLoginName(args.Value).value;
     args.IsValid = (res == "1" ? true : false);
}