/* A Bison parser, made by GNU Bison 3.0.4.  */

/* Bison interface for Yacc-like parsers in C

   Copyright (C) 1984, 1989-1990, 2000-2015 Free Software Foundation, Inc.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.

   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */

#ifndef YY_YY_Y_TAB_H_INCLUDED
# define YY_YY_Y_TAB_H_INCLUDED
/* Debug traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif
#if YYDEBUG
extern int yydebug;
#endif

/* Token type.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
  enum yytokentype
  {
    MAX = 258,
    MIN = 259,
    VARIABLE = 260,
    ASSIGN = 261,
    INTEGER = 262,
    NEWLINE = 263,
    BRO = 264,
    BRC = 265,
    UNA = 266,
    OR = 267,
    SMTH = 268,
    BGTH = 269,
    SAAS = 270,
    NSAS = 271,
    SMOS = 272,
    BGOS = 273,
    COND = 274,
    PLUS = 275,
    SUBSTRACT = 276,
    TIMES = 277,
    DIVIDE = 278,
    MODULO = 279,
    COMMA = 280
  };
#endif
/* Tokens.  */
#define MAX 258
#define MIN 259
#define VARIABLE 260
#define ASSIGN 261
#define INTEGER 262
#define NEWLINE 263
#define BRO 264
#define BRC 265
#define UNA 266
#define OR 267
#define SMTH 268
#define BGTH 269
#define SAAS 270
#define NSAS 271
#define SMOS 272
#define BGOS 273
#define COND 274
#define PLUS 275
#define SUBSTRACT 276
#define TIMES 277
#define DIVIDE 278
#define MODULO 279
#define COMMA 280

/* Value type.  */
#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef int YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define YYSTYPE_IS_DECLARED 1
#endif


extern YYSTYPE yylval;

int yyparse (void);

#endif /* !YY_YY_Y_TAB_H_INCLUDED  */
