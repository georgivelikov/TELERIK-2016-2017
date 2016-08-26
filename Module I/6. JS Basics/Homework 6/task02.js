function solve(args) {
	var arr = args;

	Array.prototype.remove = function() {
		var element = this[0];
		for(var i = 0; i < this.length; i += 1) {
			if (this[i] === element) {
				this.splice(i, 1);
				i -= 1;
			}
		}
	}

	arr.remove();

	console.log(arr.join('\n'));
}

solve(['1', '2', '1', '3', '1', '4'])