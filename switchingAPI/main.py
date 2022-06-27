from flask import Flask, jsonify
from processor import *


app = Flask(__name__)


@app.route("/answer/v1", methods=['GET'])
def answer_v1():
  data = get_answer_v1()
  return jsonify(data)

@app.route("/answer/v2", methods=['GET'])
def answer_v2():
  data = get_answer_v2()
  return jsonify(data)

@app.route("/answer/v3", methods=['GET'])
def answer_v3():
  data = get_answer_v3()
  return jsonify(data)


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5001)