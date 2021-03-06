﻿/** 
* 在iframe中调用，在父窗口中出提示框(herf方式不用调父窗口)
*/
$.extend({
    messageBox5s: function (title, msg) {
        $.messager.show({
            title: title, msg: msg, timeout: 5000, showType: 'slide', style: {
                left: '',
                right: 5,
                top: '',
                bottom: -document.body.scrollTop - document.documentElement.scrollTop + 5
            }
        });
    }
});
$.extend({
    messageBox10s: function (title, msg) {
        $.messager.show({
            title: title, msg: msg, height: 'auto', width: 'auto', timeout: 10000, showType: 'slide', style: {
                left: '',
                right: 5,
                top: '',
                bottom: -document.body.scrollTop - document.documentElement.scrollTop + 5
            }
        });
    }
});
$.extend({
    show_alert: function (strTitle, strMsg) {
        $.messager.alert(strTitle, strMsg);
    }
});

// 对数据进行四舍五入
//value:数据
//count:小数位
$.extend({
    format: function (value, count) {
        var newValue = value + "";
        var index = newValue.indexOf(".");
        if (index == -1) {
            newValue = value + ".000000";
        } else {
            newValue = value + "000000";
        }
        index = newValue.indexOf(".");
        return newValue.substr(0, index + count + 1);
    }
});

/** 
* panel关闭时回收内存，主要用于layout使用iframe嵌入网页时的内存泄漏问题
*/
//$.fn.panel.defaults.onBeforeDestroy = function () {

//    var frame = $('iframe', this);
//    try {
//        // alert('销毁，清理内存');
//        if (frame.length > 0) {
//            for (var i = 0; i < frame.length; i++) {
//                frame[i].contentWindow.document.write('');
//                frame[i].contentWindow.close();
//            }
//            frame.remove();
//            if ($.browser.msie) {
//                CollectGarbage();
//            }
//        }
//    } catch (e) {
//    }
//};
