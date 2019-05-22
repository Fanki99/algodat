%{
extern int yylval; 
extern int sym[];
extern int yyerror(char *s);
#include "y.tab.h"
extern int var;
%}

%%


min { var =0;}
max { var =1;}

0[xX][A-Fa-f0-9]+ {
        yylval = strtol(yytext, &yytext, 16);
        return INTEGER;
}

[a-z]   {
	   yylval = *yytext - 'a';
	   return VARIABLE;
        }

[0-9]+  {  
           yylval = atoi(yytext);
           return INTEGER;
        }

":="    return ASSIGN;
"+"     return PLUS;
"*"     return TIMES;
"-"     return SUBSTRACT;
"/"     return DIVIDE;
"%"     return MODULO;
"("     return BRO;
")"     return BRC;
"<"     return SMTH;
">"     return BGTH;
"=="    return SAAS;
"!="    return NSAS;
"<="    return SMOS;
">="    return BGOS;

","     return COMMA;
"min"   return MIN;
"max"   return MAX;

"?"     return COND;
":"     return OR;

"\n"    return NEWLINE;

[ \t]   ;

.       yyerror("Invalid character");

%%

int yywrap() {
 return 1;
}
