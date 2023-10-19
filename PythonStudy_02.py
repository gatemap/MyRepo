shop = ["반팔", "청바지", "이어폰", "키보드"]

#인덱싱
print(shop[0])


#슬라이싱
print(shop[0:2])

#리스트 안에 리스트에서 인덱싱
my_shop = ["반팔", "청바지", "이어폰", ["무선 키보드", "유선 키보드", "기계식 키보드"]]
print(my_shop[3])
print(my_shop[-1])
print(my_shop[2:4])


#리스트 함수 - 추가/삭제

shop = ["a", "b", "c", "d"]

#추가
shop.append("e")
print(shop)

#삭제
shop.remove("b")
print(shop)


#실습1

print()
rainbow = ['red', 'orange', 'yellow', 'green', 'blue', 'indigo', 'purple']

print(rainbow[1])
rainbow.sort()
print(rainbow)
rainbow.append('white')
print(rainbow)
del rainbow[2:6]
print(rainbow)
