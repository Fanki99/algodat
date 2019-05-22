%{
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
int sym[26];
int yylex();
int convert();
int yyerror(char *s);
int var = 0;
%}

%token MAX MIN VARIABLE ASSIGN INTEGER NEWLINE BRO BRC UNA OR
%left SMTH BGTH SAAS NSAS SMOS BGOS COND 
%left PLUS
%left SUBSTRACT
%left TIMES
%left DIVIDE
%left MODULO
%right UNA
%right COMMA



%%

program: program statement
       | 
       ;

statement: expr NEWLINE 
	     { printf("%d\n", $1); }
         | VARIABLE ASSIGN expr NEWLINE
             { sym[$1] = $3; }
         ;

expr: INTEGER            { $$ = $1; }
      | VARIABLE         { $$ = sym[$1]; }
      | expr PLUS expr   { $$ = $1 + $3; }
      | expr TIMES expr  { $$ = $1 * $3; }
      | expr SUBSTRACT expr  { $$ = $1 - $3; }
      | expr DIVIDE expr   { $$ = $1 / $3; }
      | expr MODULO expr     { $$ = $1 % $3; }
      | BRO expr BRC      {$$ = $2;}
      | PLUS expr %prec UNA {$$ = $2;}
      | SUBSTRACT expr %prec UNA {$$ = -$2;}
      | expr SMTH expr {$$ = $1<$3;}
      | expr BGTH expr {$$ = $1>$3;}
      | expr SAAS expr {$$ = $1=$3;}
      | expr NSAS expr {$$ = $1!=$3;}
      | expr SMOS expr {$$ = $1<=$3;}
      | expr BGOS expr {$$ = $1>=$3;}
      | expr COMMA expr { if(var==1){$$=$1>$3?$1:$3;}else{$$=$1<$3?$1:$3;}; }
      | MAX expr    { $$ = $2;}
      | MIN expr    { $$ = $2;}
      | expr COND expr OR expr {if($1){$$=$3;}else{$$=$5;};}

      ;

%%

int yyerror(char *s) {
  fprintf(stderr, "%s\n", s);
  return 0;
}

int main() {
  yyparse();
  return 0;
}
