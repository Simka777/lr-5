clc;
clear all;
f=@(x)2*x*x*x*sin(5*(x^0.5));
 a=input('Enter lower limit a: ');
 b=input('Enter upper limit b: ');
 n=input('Enter the  number of sub-intervals n: ');
 h=(b-a)/n;
if rem(n,3)~=0
   fprintf('\n Enter valid n!!!'); 
   n=input('\n Enter n as multiple of 3: ');
end
for k=1:1:n
  x(k)=a+k*h;
  y(k)=f(x(k));
end
 so=0;sm3=0;
for k=2:1:n-1
    if rem(k,3)==0
       sm3=sm3+y(k);
     else
     so=so+y(k);
    end
end
answer=(3*h/8)*(f(a)+f(b)+3*so+2*sm3);
fprintf('\n The value of integration is %f',answer);