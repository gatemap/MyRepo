# 실습1(set)
# 백준 14425 문제

'''
import sys

# 초기화
input = sys.stdin.readline

s = set()

n, m = map(int, input().split(' '))
# n개의 문자열 리스트(set)에 추가
for i in range(n) :
    s.add(input())
answer = 0
# 나머지 문자열 리스트가 s에 있는 문자인지 체크
for j in range(m) :
    t = input()
    if t in s :
        answer += 1

'''
        
# 실습2(dictionary)
student = {"Alice" : 85, "Bob" : 90, "Charlie" : 95}
student["David"] = 80
student["Alice"] = 88
del(student["Bob"])

for name in student.keys() :
    print(f"이름 : {name}, 점수 : {student[name]}")