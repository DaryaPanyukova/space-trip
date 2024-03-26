# Космические путешествия

Объектная модель симулятора фэнтезийного космического передвижения.

# Отрабатываемый материал

Инкапсуляция, сокрытие, композиция, полиморфизм, интроспекция, SOLID

## Сюжет

Отделу космических исследований необходима система для расчётов продолжительности космических маршрутов в различных средах, а так же расчётов возможности и оптимальности прохождения данных маршрутов определёнными типами кораблей.

## Среды

- обычный космос
для перемещения в данной среде кораблей необходимо иметь импульсный двигатель.
- туманности повышенной плотности пространства
для перемещения в данной среде импульсные двигатели имеют достаточно малую эффективность, поэтому их использование нецелесообразно. к тому же, такие туманности имеют большую пространственную площадь, поэтому перемещения через них возможно лишь по специальным подпространственным каналам. эти каналы имеют определённую длину, поэтому чтобы по ним пройти, корабль должен иметь возможность пройти канал **полностью**, **сделать это в два захода не получится**. для перемещения по подпространственным каналам необходимы специальные прыжковые двигатели.
- туманности нитринных частиц
для перемещения в данной среде кораблей необходимо иметь импульсный двигатель. контакт с нитринными частицами снижает эффективность работы импульсных двигателей, поэтому для оптимального прохождения через такие туманности, необходимо использовать импульсные двигатели экспоненциального ускорения.

Каждая среда **может** содержать соответствующее ей препятствие.

## Двигатели

- Импульсный двигатель класса C
стандартный импульсный двигатель. выдаёт константную скорость средней величины, имеет достаточно низкое потребление топлива (активной плазмы).
- Импульсный двигатель класса E
импульсный двигатель экспоненциального ускорения. выдаёт скорость, экспоненциально растущую на протяжении ускорения корабля данным двигателем. такое поведение требует больший расход топлива, чем для двигателя класса C.
- Прыжковый двигатель
существует несколько классов прыжковых двигателей (Alpha, Omega, Gamma), различаются дальностью хода по подпространственным каналам и формулой расчёта потребления специального топлива – гравитонной материи. Alpha – линейный расход, Omega – логарифмический (~n log n), Gamma – квадратичный.

Запуск импульсных двигателей всегда потребляет определённое количество топлива.

Цена топлива задаётся на Топливной Бирже и считается в кредитах Добывающей Гильдии.

## Препятствия

- Метеориты и мелкие астероиды
встречаются в обычном космосе, наносят низкий урон дефлекторам корабля, урон корпусу рассчитывается из его прочности и соотношения масса-габаритных характеристик корабля к препятствию.
- Вспышки антиматерии
встречаются в подпространственных каналах. для отражения данного препятствия корабль должен быть оснащён специальными фотонными дефлекторами, урон корпусу не наносят, но, их не отражённое фотонными дефлекторами воздействие, приведёт к гибели экипажа.
- Космо-киты
встречаются в туманностях нитринных частиц, т.к. питаются ими. наносят критический урон дефлекторам корабля, а так же уничтожают его, в случае отсутствие дефлекторов, в силу своих монструозных габаритов.  для избежания контакта с космо-китами может быть использован анти-нитринный излучатель, он маскирует сигнал нитринных-частиц, что приводит к тому, что зона следования корабля становится для них не привлекательной территорией. могут встречаться с различной плотностью популяции (различное количество столкновений за одно препятствие)

## Корабли

- Прогулочный челнок
Простой корабль оснащённый импульсным двигателем класса C. Не имеет дефлекторов, имеет корпус класса прочности 1 и малые масса-габаритные характеристики.
- Ваклас
Исследовательский корабль. Оснащён импульсным двигателем класса E и прыжковым двигателем класса Gamma, имеет дефлекторы класса 1, корпус класса прочности 2 и средние масса-габаритные характеристики.
- Мередиан
Добывающий корабль. Оснащён импульсным двигателем класса E и анти-нитринным излучателем, имеет дефлекторы класса 2, корпус класса прочности 2 и средние масса-габаритные характеристики.
- Стелла
Дипломатический корабль. Оснащён импульсным двигателем класса C и прыжковым двигателем класса Omega, имеет дефлекторы класса 1, корпус класса прочности 1 и малые масса-габаритные характеристики.
- Авгур
Боевой корабль. Оснащён импульсным двигателем класса E и прыжковым двигателем класса Alpha, имеет дефлекторы класса 3, корпус класса прочности 3 и большие масса-габаритные характеристики.

## Дефлекторы

- класс 1
выдерживают урон, наносимый двумя мелкими астероидами или одним метеоритом, после отражения этих препятствий – отключаются
- класс 2
выдерживают урон, наносимый десятью мелкими астероидами или тремя метеоритами, после отражения этих препятствий – отключаются
- класс 3
выдерживают урон, наносимый 40 мелкими астероидами, десятью метеоритами или одним космо-китом, после отражения этих препятствий – отключаются
- фотонные дефлекторы
модификация дефлекторов, позволяющая отражать 3 вспышки антиматерии. может быть установлена на любой класс дефлекторов.

## Классы прочности корпуса

- класс 1
выдерживает урон, наносимый одним мелким астероидом, любой дальнейший урон приводит к уничтожению корабля
- класс 2
выдерживает урон, наносимый пятью мелкими астероидами или двумя метеоритами, любой дальнейший урон приводит к уничтожению корабля
- класс 3
выдерживает урон, наносимый 20 мелкими астероидами или пятью метеоритами, любой дальнейший урон приводит к уничтожению корабля

## Маршрут

- Состоит из нескольких отрезков пути
- Отрезок пути представляет собой расстояние и какую-либо среду
- Результатом прохождения может быть
    - Успех
    Содержит время прохождения маршрута, истраченное на данном пути топливо
    - Потеря корабля
    Происходит в случае нехватки дальности прыжкового двигателя
    - Уничтожение корабля
    - Гибель экипажа
