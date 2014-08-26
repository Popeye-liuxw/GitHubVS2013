var agt = navigator.userAgent.toLowerCase();
var is_opera = (agt.indexOf("opera") != -1);
var is_ie = (agt.indexOf("msie") != -1) && document.all && !is_opera;
var is_ie5 = (agt.indexOf("msie 5") != -1) && document.all;
var uniqnum_counter = (new Date).getTime();
var is_regexp = (window.RegExp) ? true : false;
var gidname = '';


function $(objId)
{
	return document.getElementById(objId);
}

function $t(parentobj, tag)
{
	if (typeof parentobj.getElementsByTagName != 'undefined') {
		return parentobj.getElementsByTagName(tag);
	} else if (parentobj.all && parentobj.all.tags) {
		return parentobj.all.tags(tag);
	} else {
		return null;
	}
}

function $c(s)
{
	return document.createElement(s);
}
function swap(s,a,b,c)
{
	$(s)[a]=$(s)[a]==b?c:b;
}
function exist(s)
{
	return $(s)!=null;
}
function dw(s)
{
	document.write(s);
}
function hide(s)
{
	$(s).style.display=$(s).style.display=="none"?"":"none";
}
function isNull(_sVal)
{
	return (_sVal == "" || _sVal == null || _sVal == "undefined");
}
function removeNode(s)
{
	if(exist(s))
	{
		$(s).innerHTML = '';
		$(s).removeNode?$(s).removeNode():$(s).parentNode.removeChild($(s));
	}
}
function myInnerHTML(idname, html)
{
	if (exist(idname))
	{
		$(idname).innerHTML = html;
	}
}
function strLen(key){
	var l=escape(key),len
	len=l.length-(l.length-l.replace(/\%u/g,"u").length)*4
	l=l.replace(/\%u/g,"uu")
	len=len-(l.length-l.replace(/\%/g,"").length)*2
	return len
}


function dialog()
{
	var titile = 'YiCRM提示';
	var width = 350;
	var height = 120;
	var path = "http://img.hopebook.net/images/ziliao/";
	var sFunc = '<input id="dialogOk" type="button" value=" 确 定 " onclick="new dialog().reset();" /> <input id="dialogCancel" type="button" value=" 取 消 " onclick="new dialog().reset();" />';
	var sClose = '<div style="border:1px solid #fff; padding-left:1px;padding-right:1px;padding-top:0px;text-align:center"><a href="javascript:void(null);" style="text-decoration:none;color:#fff;" onclick="new dialog().reset();"><b>×</b></a></div>';
	var sBody = '\
		<table id="dialogBodyBox" border="0" align="center" cellpadding="0" cellspacing="6" width="100%">\
			<tr height="10"><td colspan="4"></td></tr>\
			<tr><td colspan="4" align="center">\
			<div id="dialogMsgDiv" style="text-align:center"><div id="dialogMsg" style="font-size:14px;line-height:180%;color:#2a5db0;font-weight:bold;">&nbsp;</div></div>\
			</td></tr>\
			<tr><td id="dialogFunc" colspan="4" align="center">' + sFunc + '</td></tr>\
			<tr height="5"><td colspan="4" align="center"></td></tr>\
		</table>\
	';

	var sBox = '\
		<div id="dialogBox" style="border:1px solid #1e4775;display:none;z-index:10;width:'+width+'px;">\
		<table width="100%" border="0" cellpadding="0" cellspacing="0">\
			<tr height="24" bgcolor="#6795B4">\
				<td>\
					<table onselectstart="return false;" style="-moz-user-select:none;" width="100%" border="0" cellpadding="0" cellspacing="0" style="background-color:#6688ee;  height:25px; border-top:1px solid #92c3ec;">\
						<tr>\
							<td width="6" height="24"></td>\
							<td id="dialogBoxTitle" style="color:#fff;font-size:12px;font-weight:bold;">&nbsp;</td>\
							<td id="dialogClose" width="20" align="right" valign="middle">\
								' + sClose + '\
							</td>\
							<td width="6"></td>\
						</tr>\
					</table>\
				</td>\
			</tr>\
			<tr id="dialogHeight" style="height:' + height + '" valign="top">\
				<td id="dialogBody" bgcolor="#ffffff">' + sBody + '</td>\
			</tr>\
		</table></div><div id="dialogBoxShadow" style="display:none;z-index:9;"></div>\
	';
	var sIfram = '\
		<iframe id="dialogIframBG" name="dialogIframBG" frameborder="0" marginheight="0" marginwidth="0" hspace="0" vspace="0" scrolling="no" style="position:absolute;z-index:8;display:none;"></iframe>\
	';
	
	var sBG = '\
		<div id="dialogBoxBG" style="position:absolute;top:0px;left:0px;width:100%;height:100%;"></div>\
	';

	this.show = function()
	{
		this.middle('dialogBox');
		if ($('dialogIframBG'))
		{
			$('dialogIframBG').style.top = $('dialogBox').style.top;
			$('dialogIframBG').style.left = $('dialogBox').style.left;
			$('dialogIframBG').style.width = $('dialogBox').offsetWidth;
			$('dialogIframBG').style.height = $('dialogBox').offsetHeight;
			$('dialogIframBG').style.display = 'block';
		}
		if (!is_opera) {
			this.shadow();
		}
	}

	this.reset = function()
	{
		this.close();
		_set_id_focus();
	}
	
	this.resets = function(parentobj, _sName)
	{
		this.close();
		try {parentobj._sName.submit();}catch (e){}
	}

	this.close = function()
	{
		if ($('dialogIframBG')) {
			$('dialogIframBG').style.display = 'none';
		}
		$('dialogBox').style.display='none';
		$('dialogBoxBG').style.display='none';
		$('dialogBoxShadow').style.display = "none";
		myInnerHTML('dialogBody', sBody);
	}
	this.html = function(_sHtml)
	{
		myInnerHTML('dialogBody', _sHtml);
		this.show();
	}

	this.init = function()
	{
		$('dialogCase') ? $('dialogCase').parentNode.removeChild($('dialogCase')) : function(){};
		var oDiv = document.createElement('span');
		oDiv.id = "dialogCase";
		if (!is_opera) {
			oDiv.innerHTML = sBG + sIfram + sBox;
		} else {
			oDiv.innerHTML = sBG + sBox;
		}
		document.body.appendChild(oDiv);
		$('dialogBoxBG').style.height = document.body.scrollHeight;		
	}

	this.button = function(_sId, _sFuc)
	{
		if($(_sId)) {
			$(_sId).style.display = '';
			if($(_sId).addEventListener) {
				if($(_sId).act) {
					$(_sId).removeEventListener('click', function(){eval($(_sId).act)}, false);
				}
				$(_sId).act = _sFuc;
				$(_sId).addEventListener('click', function(){eval(_sFuc)}, false);
			} else {
				if($(_sId).act) {
					$(_sId).detachEvent('onclick', function(){eval($(_sId).act)});
				}
				$(_sId).act = _sFuc;
				$(_sId).attachEvent('onclick', function(){eval(_sFuc)});
			}
		}
	}

	this.shadow = function()
	{
		var oShadow = $('dialogBoxShadow');
		var oDialog = $('dialogBox');
		oShadow['style']['position'] = "absolute";
		oShadow['style']['display']	= "";		
		oShadow['style']['opacity']	= "0.1";
		oShadow['style']['filter'] = "alpha(opacity=10)";
		oShadow['style']['background']	= "#000";

		try {
			var aIframe = parent.document.getElementById("iframe_parent");
		} catch (e){}
		if (aIframe) {
			var sClientWidth = aIframe.offsetWidth;
			var sClientHeight = aIframe.offsetHeight;
			var sScrollTop = 0;
		} else {
			var sClientWidth = parent ? parent.document.body.clientWidth : document.body.clientWidth;
			var sClientHeight = parent ? parent.document.body.clientHeight : document.body.clientHeight;
			var sScrollTop = parent ? parent.document.body.scrollTop : document.body.scrollTop;
		}

		oShadow['style']['top'] = '0';
		oShadow['style']['left'] = '0';
		oShadow['style']['width'] = sClientWidth;
		oShadow['style']['height'] = sClientHeight + sScrollTop;
	}

	this.open = function(_sUrl, _sMode, _sClose)
	{		
		this.show();
		if(!_sMode || _sMode == "no" || _sMode == "yes"){
			var openIframe = "<iframe width='100%' height='100%' name='iframe_parent' id='iframe_parent' src='" + _sUrl + "' frameborder='0' scrolling='" + _sMode + "'></iframe>";
			myInnerHTML('dialogBody', openIframe);
		}
		_sClose ? this.button('dialogBoxClose', _sClose) : function(){};
	}

	this.showWindow = function(_sUrl, _iWidth, _iHeight, _sMode)
	{
		var oWindow;
		var sLeft = (screen.width) ? (screen.width - _iWidth)/2 : 0;
		var iTop = -80 + (screen.height - _iHeight)/2;
		iTop = iTop > 0 ? iTop : (screen.height - _iHeight)/2;
		var sTop = (screen.height) ? iTop : 0;
		if(window.showModalDialog && _sMode == "m"){
			oWindow = window.showModalDialog(_sUrl,"","dialogWidth:" + _iWidth + "px;dialogheight:" + _iHeight + "px");
		} else {
			oWindow = window.open(_sUrl, '', 'height=' + _iHeight + ', width=' + _iWidth + ', top=' + sTop + ', left=' + sLeft + ', toolbar=no, menubar=no, scrollbars=' + _sMode + ', resizable=no,location=no, status=no');
			this.reset();
		}
	}

	this.event = function(_sMsg, _sOk, _sCancel, _sClose)
	{
		myInnerHTML('dialogFunc', sFunc);
		myInnerHTML('dialogClose', sClose);
		$('dialogBodyBox') == null ? $('dialogBody').innerHTML = sBody : function(){};
		$('dialogMsg') ? $('dialogMsg').innerHTML = _sMsg  : function(){};

		_sOk && _sOk != "" ? this.button('dialogOk', _sOk) : $('dialogOk').style.display = 'none';
		_sCancel && _sCancel != "" ? this.button('dialogCancel', _sCancel) : $('dialogCancel').style.display = 'none';
		_sClose ? this.button('dialogBoxClose', _sClose) : function(){};

		this.show();
	}

	this.set = function(_oAttr, _sVal)
	{
		var oShadow = $('dialogBoxShadow');
		var oDialog = $('dialogBox');
		var oHeight = $('dialogHeight');

		if(!isNull(_sVal)) {
			switch(_oAttr)
			{
				case 'title':
					myInnerHTML('dialogBoxTitle', _sVal);
					break;
				case 'width':
					oDialog['style']['width'] = _sVal;
					break;
				case 'height':
					oHeight['style']['height'] = _sVal;
					break;
			}
		}
		this.middle('dialogBox');
		oShadow['style']['top'] = oDialog.offsetTop + 6;
		oShadow['style']['left'] = oDialog.offsetLeft + 6;
		oShadow['style']['width'] = oDialog.offsetWidth;
		oShadow['style']['height'] = oDialog.offsetHeight;
	}

	this.middle = function(_sId)
	{
		try {
			var aIframe = parent.document.getElementById("iframe_parent");
		} catch (e){}
		if (aIframe) {
			var sClientWidth = aIframe.offsetWidth;
			var sClientHeight = aIframe.offsetHeight;
			var sScrollTop = 0;
		} else {
			var sClientWidth = parent ? parent.document.body.clientWidth : document.body.clientWidth;
			var sClientHeight = parent ? parent.document.body.clientHeight : document.body.clientHeight;
			var sScrollTop = parent ? parent.document.body.scrollTop : document.body.scrollTop;
		}
		
		var sleft = (document.body.clientWidth / 2) - ($(_sId).offsetWidth / 2);

		var iTop = -80 + (sClientHeight / 2 + sScrollTop) - ($(_sId).offsetHeight / 2);
		var sTop = iTop > 0 ? iTop : (sClientHeight / 2 + sScrollTop) - ($(_sId).offsetHeight / 2);
		$(_sId)['style']['display'] = '';
		$(_sId)['style']['position'] = "absolute";
		$(_sId)['style']['left'] = sleft;
		$(_sId)['style']['top'] = sTop;
	}
}

function _msg_show(msg,title,width,height){
    title = title ? title : 'YiCRM提示';
    dg=new dialog();
    dg.init();
    dg.set('title', title);
	if (width) {
        dg.set('width', width);
    }
    if (height) {
        dg.set('height', height);
    }
    dg.event(msg,'','','');		
}

function _error_msg_show(msg, click, idname, title)
{
	gidname = idname;
    click = click ? click : ' ';
    title = title ? title : 'YiCRM提示';
    dg=new dialog();
    dg.init();
    dg.set('title', title);
    dg.event(msg, click, '', click);
}

function _error_msg_show_parent(msg, click, idname, title)
{
	gidname = idname;
    click = click ? click : ' ';
    title = title ? title : 'YiCRM提示';
    dg=new parent.dialog();
    dg.init();
    dg.set('title', title);
    dg.event(msg, click, '', click);
}

function _confirm_msg_show(msg, click_ok, click_no, title, width, height)
{
    click_ok = click_ok ? click_ok : ' ';
    click_no = click_no ? click_no : ' ';
    title = title ? title : 'YiCRM提示';

    dg=new dialog();
    dg.init();
    dg.set('title', title);
	if (width) {
        dg.set('width', width);
    }
    if (height) {
        dg.set('height', height);
    }
    dg.event(msg, click_ok, click_no, click_no);
}

function _confirm_msg_show_parent(msg, click_ok, click_no, title, width, height)
{
    click_ok = click_ok ? click_ok : ' ';
    click_no = click_no ? click_no : ' ';
    title = title ? title : 'YiCRM提示';

    dg=new parent.dialog();
    dg.init();
    dg.set('src', '');
    dg.set('title', title);
	if (width) {
        dg.set('width', width);
    }
    if (height) {
        dg.set('height', height);
    }
    dg.event(msg, click_ok, click_no, click_no);
}

function _set_id_focus()
{
	if (!isNull(gidname)) {
		try {$(gidname).focus();}catch (e){}
	}
}

function openWindow(_sUrl, _sWidth, _sHeight, _sTitle, _sClickNo, _sScroll)
{
	var oEdit = new dialog();
	oEdit.init('yes');
	oEdit.set('title', _sTitle ? _sTitle : "系统信息提示" );
	oEdit.set('width', _sWidth);
	oEdit.set('height', _sHeight);
	oEdit.open(_sUrl, _sScroll != "yes" ? 'no' : 'yes', _sClickNo);
}

function zsxz(ta, zs, maxl)
{
	if(ta.value.length > maxl) {
		ta.value = ta.value.substring(0,maxl);
	} else {
		zs.value = maxl - ta.value.length;
	}
}

/******************************************/
function LI_Ajax(async)
{
	this.async = async ? true : false;
}
LI_Ajax.prototype.init = function()
{
	try {
		this.handler = new XMLHttpRequest();
		return true;
	} catch(e) {
		try {
			this.handler = new ActiveXObject('Microsoft.XMLHTTP');
			return true;
		} catch(e) {
			try {
				this.handler = new ActiveXObject('Msxml2.XMLHTTP');
				return true;
			} catch(e) {
				return false;
			}
		}
	}
}
LI_Ajax.prototype.not_ready = function()
{
	return (this.handler.readyState && (this.handler.readyState < 4));
}
LI_Ajax.prototype.onreadystatechange = function(event)
{
	if (!this.handler) {
		this.init();
	}
	if (typeof event == 'function') {
		this.handler.onreadystatechange = event;
	} else {
		alert('XML Sender OnReadyState event Must function');
	}
}
LI_Ajax.prototype.post = function(desturl, datastream)
{
	if (!this.handler)
	{
		this.init();
	}
	if (!this.not_ready())
	{
		this.handler.open('POST', desturl, this.async);
		if (typeof(this.handler.setRequestHeader) != "undefined")
		{
			this.handler.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
		}
		this.handler.send(datastream);

		if (!this.async && this.handler.readyState == 4 && this.handler.status == 200)
		{
			return true;
		}
	}
	return false;
}
LI_Ajax.prototype.get = function(desturl, datastream)
{
	if (!this.handler)
	{
		this.init();
	}
	if (!this.not_ready())
	{
		this.handler.open('GET', desturl + "?" + datastream, this.async);
		this.handler.send(null);

		if (!this.async && this.handler.readyState == 4 && this.handler.status == 200)
		{
			return true;
		}
	}
	return false;
}

function phpUrlEncode (text)
{
	return escape(text).replace(/\+/g, "%2B");
}

var ajax_compatible = (is_opera ? false : LI_Ajax.prototype.init());



