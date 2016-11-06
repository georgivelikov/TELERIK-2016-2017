//'use strict';

class listNode {
    constructor(value) {
        this.value = value;
    }

    get value(){
        return this._value;
    }
    set value(newValue){
        this._value = newValue;
    }

    get nextValue(){
        return this._nextValue;
    }
    set nextValue(newNextValue){
        this._nextValue = newNextValue;
    }

    get prevValue(){
        return this._prevValue;
    }
    set prevValue(newPrevValue){
        this._prevValue = newPrevValue;
    }

    get index(){
        return this._index;
    }
    set index(newIndex){
        this._index = newIndex;
    }
}

class LinkedList {
    constructor() {
        this._length = 0;
    }
    get length(){
        return this._length;
    }
    get first(){
        return this._head.value;
    }
    get last(){
        return this._tail.value;
    }
    get head(){
        return this._head;
    }
    set head(newHead){
        this._head = newHead;
    }

    get tail(){
        return this._tail;
    }
    set tail(newTail){
        this._tail = newTail;
    }

    append(...args){
        var nodesList = [];
        var startNodeIndex = 0;
        for(var i = 0; i < args.length; i += 1){
            var newNode = new listNode(args[i]);
            nodesList.push(newNode);
        }

        if(this.head === undefined){
            this.head = nodesList[0];
            this.tail = nodesList[0];
            startNodeIndex = 1;
            this._length = 1;
        }

        for(var i = startNodeIndex; i < nodesList.length; i += 1){
            this.tail.nextValue = nodesList[i];
            nodesList[i].prevValue = this.tail;
            this.tail = nodesList[i];
            this._length++;
        }

        this.setIndeces();

        return this;
    }

    prepend(...args){
        var nodesList = [];
        
        for(var i = 0; i < args.length; i += 1){
            var newNode = new listNode(args[i]);
            nodesList.push(newNode);
        }

        var startNodeIndex = nodesList.length - 1;

        if(this.head === undefined){
            this.head = nodesList[nodesList.length - 1];
            this.tail = nodesList[nodesList.length - 1];
            this._length = 1;
            startNodeIndex--;
            if(startNodeIndex < 0){
                return this;
            }
        }

        for(var i = startNodeIndex; i >= 0; i -= 1){
            this.head.prevValue = nodesList[i];
            nodesList[i].nextValue = this.head;
            this.head = nodesList[i];
            this._length++;
        }

        this.setIndeces();

        return this;
    }

    [Symbol.iterator](){
        var current = this.head;

        return {
            next() {
                if (current !== undefined) {
                    let valueToReturn = current.value;
                    current = current.nextValue;

                    return { value: valueToReturn, done: false };
                }

                return { value: undefined, done: true };
            }
        };
    }

    setIndeces(){
        var current = this.head;
        var counter = 0;
        while(current.nextValue !== undefined){
            current.index = counter;
            counter++;
            current = current.nextValue;
        }

        
    }

    at(index, value){
        if(value === undefined){
            var current = this.head;
            if(index === this._length - 1){
                return this.last;
            }
            while(current.nextValue !== undefined){
                if(current.index === index){
                    return current.value;
                }

                current = current.nextValue;
            }
        } else {
            var current = this.head;
            if(index === this._length - 1){
                this.tail.value = value;
            }
            while(current.nextValue !== undefined){
                if(current.index === index){
                    current.value = value;
                    return;
                }

                current = current.nextValue;
            }
        }
    }

    nodeAt(index, value){
        if(value === undefined){
            var current = this.head;
            if(index === this._length - 1){
                return this.tail;
            }
            while(current.nextValue !== undefined){
                if(current.index === index){
                    return current;
                }

                current = current.nextValue;
            }
        } else {
            var current = this.head;
            if(index === this._length - 1){
                this.tail = value;
            }
            while(current.nextValue !== undefined){
                if(current.index === index){
                    current = value;
                    return;
                }

                current = current.nextValue;
            }
        }
    }

    insert(...args){
        var index = args[0] - 1;
        if(index === -1){
            var arr = args.slice(1);
            this.insertPrepend(arr);
            return this;
        }
        if(index === this._length - 2){
            var arr = args.slice(1);
            this.insertAppend(arr);
            return this;
        }

        var startNode = this.nodeAt(index);
        var endNode = startNode.nextValue;

        for(var i = 1; i < args.length; i += 1){
            var newNode = new listNode(args[i]);
            startNode.nextValue = newNode;
            newNode.prevValue = startNode;
            startNode = newNode;
            this._length++;
        }

        endNode.prevValue = startNode;
        startNode.nextValue = endNode;

        this.setIndeces();

        return this;
    }

    insertAppend(args){
        var helperList = new LinkedList();
        helperList.append(...args);

        helperList.head.prevValue = this.tail;
        this.tail.nextValue = helperList.head;
        this.tail = helperList.tail;

        this._length += helperList.length;
        this.setIndeces();
    }

    insertPrepend(args){
        var helperList = new LinkedList();
        helperList.append(...args);

        this.head.prevValue = helperList.tail;
        helperList.tail.nextValue = this.head;
        this.head = helperList.head;

        this._length += helperList.length;
        this.setIndeces();
    }

    removeAt(index){
        var nodeToRemove = this.nodeAt(index);

        var prev = nodeToRemove.prevValue;
        var next = nodeToRemove.nextValue;
        var valueToReturn = nodeToRemove.value;
        
        if(prev !== undefined){
            prev.nextValue = next;
        }
        if(index === 0){
            this.head = next;
        }

        if(next !== undefined){
            next.prevValue = prev;
        }
        if(index === this._length - 1){
            this.tail = prev;
        }
        
        this._length--;
        this.setIndeces();
        nodeToRemove = null;
        return valueToReturn;
    }

    toArray(){
        var arr = [];
        for(let item of this){
            arr.push(item);
        }

        return arr;
    }

    toString(){
        return this.toArray().join(' -> ');
    }
}


// const values = ['test', true, null, 1, 2, 'testtest', { value: 'val', message: 'hello' }, 'gg'],
//             list = new LinkedList().append(...values);
//             console.log(list.toString());
//             var removed1 = list.removeAt(1),
//             removed2 = list.removeAt(1),
//             removed3 = list.removeAt(0),
//             removed4 = list.removeAt(list.length - 1);
//             console.log(list.toString());
module.exports = LinkedList;