<?php
	$file_name = './scores.txt';
	$content = $_POST["_content"];

	file_put_contents($file_name, $content, FILE_APPEND);
?>