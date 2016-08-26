function solve(args){
	var globalPriority = 0;
	var inSelectorPriority = 0;
	var inLinePriority = -1;
	
	var inSelector = false;
	var currentSelector;
	var priorities = {};
	var selectors = {};
	var valuePriorities = {};

	var regexForKliomba = /\s*@\s*(\d+)\s*/;
	var regexSelector = /\s*([a-z\d]+?)\s*{/;
	var regexBind = /\s*([\w\-]+?)\s*:\s*([^:;{}@]+)\s*/;

	for (var i = 0; i < args.length; i++) {
		line = '' + args[i].trim();
		//line = line.replace(/\s+/g, ' ');
		if (line.indexOf('{') > -1 && line.indexOf('@') < 0) {
			var extractedSelector = line.match(regexSelector)[1];
			priorities[extractedSelector] = globalPriority;
			currentSelector = extractedSelector;
			inSelector = true;
		}
		else if (line.indexOf('{') > -1 && line.indexOf('@') > -1) {
			var extractedSelector = line.match(regexSelector)[1];
			var pr = +line.match(regexForKliomba)[1];
			priorities[extractedSelector] = pr;
			currentSelector = extractedSelector;
			inSelector = true;
		}
		else if (line.indexOf(':') > -1 && line.indexOf('@') > -1 && inSelector && line.indexOf(':') < line.indexOf('@') && inSelector) {
			var pr = +line.match(regexForKliomba)[1];
			inLinePriority = pr;
		}
		else if(inSelector &&  line.indexOf('@') > -1){
			var pr = +line.match(regexForKliomba)[1];
			priorities[currentSelector] = pr;
		}
		else if(!inSelector &&  line.indexOf('@') > -1) {
			var pr = +line.match(regexForKliomba)[1];
			globalPriority = pr;
		}

		if (line.indexOf(':') > -1) {
			var name = line.match(regexBind)[1];
			var value = line.match(regexBind)[2];
			var currentPriority = priorities[currentSelector];
			if (inLinePriority > -1) {
				currentPriority = inLinePriority;
				inLinePriority = -1;
			}

			if (selectors[currentSelector] == undefined) {
				selectors[currentSelector] = {};
			}

			if (valuePriorities[currentSelector] == undefined) {
				valuePriorities[currentSelector] = {};
			}

			if (selectors[currentSelector][name] == undefined) {
				selectors[currentSelector][name] = value.trim();
				valuePriorities[currentSelector][name] = currentPriority;
				continue;
			}

			if (valuePriorities[currentSelector][name] < currentPriority) {
				valuePriorities[currentSelector][name] = currentPriority;
				selectors[currentSelector][name] = value.trim();
			}

		}

		if (line.indexOf('}') > -1) {
			inSelector = false;
		}
		
		inLinePriority = -1;
	}

	var final = [];
	for (var selector in selectors) {
		var obj = selectors[selector];
		var keys = [];

		for (var key in obj) {
			keys.push(key);
		}

		keys.sort();
		
		for (var p = 0; p < keys.length; p++) {
			var k = keys[p];
			final.push(`${selector} { ${k}: ${obj[k]}; }`);
		}
	}

	final.sort();
	console.log(final.join('\n'));
}

var test1 = [
'        arguer   { ',     
'   s-i-sters    :      lxaKUudI     20  ; ',
'    siza-ble     :      introduced ;  ',
' }    ',
'   finished      {',      
' tr-unks:hY    ;  ',   
'    ordinar-il-y : collections     ;   ',
' arti-factually   :     efforts    ; ', 
'      }    ',
'   rudders      {  ',
'     siza-ble    :    retarded; ',
'   }  ',
'  payments  { ',
' siza-ble:      firefly;',
' i-llumina-ting   :    at*7A8q    ; ',    
'   } ',
' parallelized     {     ',
'      freshened     :colonizer     ; ',
'sharp-en :     QB ;   ',
'arti-factually    :  airlocks;     ',
'    }    ',
'     @ 3     ',
'     vacuum {  ',
'     }     ',
'   arguer    {     ',
'     sharp-en:   IJYZcbs#         18    ; ',
' } ',
'  addend      {    ',
'ordinar-il-y :  _33  ;',
'  i-llumina-ting : !O!Y    ;  ',
'  stripping:   QlkBEo;    ',
'     siza-ble   :      sonnets  ;',
'    }  ',
'  addend{',
'}',
' payments   {      ',
'     i-llumina-ting   :     acute ;   ',  
' sharp-en      :     gsHQ%XWw        3    ; ',
'tr-unks      :    cbD8o+  ;     ',
' sharp-en:     GKmYNo3 ;',
'  tr-unks  :    foxs     ; ',
'     bott-led :   skulker  ;    ',
'   }',
'     vacuum {',
'    ordinar-il-y  :      DmGeC  ;   ',
'ordinar-il-y    :    burdens       13   ;', 
'      s-i-sters    : evty     ;   ',
'     stripping :     compellingly  ;',
'   s-i-sters  : outweighs  ; ',
'      }      ',
'    rudders    { ',
'     freshened:     jv+x    ; ',
'     sharp-en      : I!mAs    15     ; ',
' ordinar-il-y  :     boxtops; ',
'    sharp-en   :     UQC#   ;      ',
'freshened   :    dolls   ;   ',
'     }      ',
'  parallelized {      ',
'   tr-unks  :    2_QGiReE; ',
' se-r-geant     :presuming    ;',
'     s-i-sters      :      organizations   ;',
'      stripping :      EF0vB  ; ',
'   freshened  :     W&zsrqBq    ;   ',
'      i-llumina-ting :   vaV%niG   ;      ',
'arti-factually    :      9p1eJ_Z      15   ;',
'    }   ',
'rudders  {   ',
'} ',
];

solve(test1);