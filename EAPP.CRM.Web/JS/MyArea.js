function MyArea(mDiv,hide,val,breadonly)
{
    var topdiv = document.createElement("div");
    topdiv.id = "topdiv" + mDiv.id;
    
    var hide2 = document.createElement("input");
    
//    var lbl = document.createElement("lable");
//    lbl.innerText = "地区:";
    
    
    hide2.id="selid" + mDiv.id;
    hide2.type = "hidden";
    hide2.name = "selid";    
    
    mDiv.appendChild(topdiv);
//    mDiv.appendChild(hide);
    mDiv.appendChild(hide2);
//    topdiv.appendChild(lbl);

    function change(){
        var parentValue = document.getElementById(hide2.value).value;
        var result = GetDataTable(parentValue);
        
        var allsels = topdiv.getElementsByTagName("select");
            
        var sels = new Array();    
        for(var k = 0; k < allsels.length; k++)
        {    
            sels[k] = topdiv.childNodes[k];            
            if(topdiv.childNodes[k].id==hide2.value)
            {   
                break;
            }
        }
        
        for(var q = 0; q < allsels.length;)
        {
            topdiv.removeChild(allsels[q]);
        }
        
        for(var i = 0; i < sels.length; i++)
        {
            topdiv.appendChild(sels[i]);
        }
        
        if(result.Rows.length>0)
        {   
            var subsel = document.createElement("select");
            subsel.id="div" + Math.random();
            subsel.onchange = change;
            subsel.onclick = function()
            {
                hide2.value = subsel.id;    
            }
            subsel.options.add(new Option("请选择…","-1"));
            for(var p = 0; p < result.Rows.length;p++)
            {
                subsel.options.add(new Option(result.Rows[p].AreaName,result.Rows[p].AreaId));
            }            
            topdiv.appendChild(subsel);
            hide2.value = subsel.id;
            subsel.fireEvent("onchange");
            if(parentValue != "-1")
            {
                hide.value = parentValue;
            }
        }else
        {
            if(parentValue != "-1")
            {
                hide.value = parentValue;
            }
        }        
    }
    
    function createSelect(city)
    {   
        if(city[2] != "0")
        {
            var sel1 = document.createElement("select");
            sel1.id = "sel" + Math.random();        
            sel1.onchange = change;
            sel1.onclick = function()
            {
                hide2.value = sel1.id;    
            }
            var result = GetDataTable(city[2]);            
                        
            sel1.options.add(new Option("请选择…","-1"));
            for(var i = 0; i < result.Rows.length;i++)
            {
                sel1.options.add(new Option(result.Rows[i].AreaName,result.Rows[i].AreaId));
            }            
            sel1.value = city[0];
            createSelect(GetData(city[2]));                        
            topdiv.appendChild(sel1);
        }
        else
        {
            var result1 = GetDataTable(city[2]);            
            var select = document.createElement("select");
            select.id = "sel01" + mDiv.id;
            select.options.add(new Option("请选择…","-1"));
            for(var k = 0; k < result1.Rows.length;k++)
            {
                select.options.add(new Option(result1.Rows[k].AreaName,result1.Rows[k].AreaId));
            }
            select.onchange = change;
            select.onclick = function()
            {
                hide2.value = select.id;    
            }
            hide2.value = select.id;
            select.value = city[0];
            topdiv.appendChild(select);            
        }
    }
    
    this.init = function()
    {
        if(!val){
            var result = GetDataTable("0");
            if(!result || !result.Rows || result.Rows.length < 1)
            {
                alert("没有数据");
                return;
            }   
            var select = document.createElement("select");
            select.id = "sel01" + mDiv.id;
            select.options.add(new Option("请选择…","-1"));
            for(var i = 0; i < result.Rows.length;i++)
            {
                select.options.add(new Option(result.Rows[i].AreaName,result.Rows[i].AreaId));
            }
            select.onchange = change;   
            select.onclick = function()
            {
                hide2.value = select.id;
            }   
            hide2.value = select.id;  
            topdiv.appendChild(select);
            hide.value = select.value;            
            select.fireEvent("onchange");
        } else {
            var resulta = GetData(val);
            createSelect(resulta);
            
            var subres = GetDataTable(resulta[0]);
            
            if(subres.Rows.length > 0)
            {   
                var sel2 = document.createElement("select");
                sel2.id = "sel" + Math.random();
                
                sel2.onchange = change;
                sel2.onclick = function()
                {
                    hide2.value = sel2.id;    
                }                
                sel2.options.add(new Option("请选择…","-1"));
                for(var k = 0; k < subres.Rows.length; k++)
                {
                    sel2.options.add(new Option(subres.Rows[k].AreaName,subres.Rows[k].AreaId));
                }   
                topdiv.appendChild(sel2);
            }
            
        }
    }    
}